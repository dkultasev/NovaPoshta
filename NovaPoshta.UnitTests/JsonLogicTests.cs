using System;
using System.Collections.Generic;
using FluentAssertions;
using Moq;
using NovaPoshta.Json;
using NUnit.Framework;
using RestSharp;

namespace NovaPoshta.UnitTests
{
    public class JsonLogicTests
    {
        private Mock<IRestClient> _clientMock;
        private NovaPoshtaConfig _config;

        [SetUp]
        public void Init()
        {
            _clientMock = new Mock<IRestClient>();
            _config = new InitialSetup().Config;
        }

        [Test]
        public void Test_When_ResponseException_Is_Thrown_ErrorsList_Contains_Errors()
        {
            try
            {
                throw new ResponseException(new List<string>() {"1", "2"});
            }
            catch (ResponseException e)
            {
                e.Errors.Length.Should().Be(2);
            }
        }

        [Test]
        public void Test_When_There_Are_Errors_Returned_Then_GetListOfObjects_Throw_Exception()
        {
            _clientMock.Setup(cl => cl.Execute<List<RootObject<object>>>(It.IsAny<IRestRequest>()))
                .Returns(new RestResponse<List<RootObject<object>>>()
                {
                   Data = new List<RootObject<object>>()
                   {
                       new RootObject<object>()
                       {
                           errors =  new List<object> { "1", "2" }
                       }
                   }
                });

            ((Action)(() => new JsonLogic(_clientMock.Object, _config).GetListOfObjects<object>("","",""))).ShouldThrowExactly<ResponseException>();
        }

        [Test]
        public void Test_When_There_Are_Errors_Returned_Then_ModifyObject_Throw_Exception()
        {
            _clientMock.Setup(cl => cl.Execute<RootObject<object>>(It.IsAny<IRestRequest>()))
                .Returns(new RestResponse<RootObject<object>>()
                {
                   Data = new RootObject<object>()
                   {
                       errors = new List<object> { "1", "2" }
                   }
                });

            ((Action)(() => new JsonLogic(_clientMock.Object, _config).ModifyObject<object>("","",""))).ShouldThrowExactly<ResponseException>();
        }

        [Test]
        [TestCaseSource(nameof(CtorParameters))]
        public void Test_When_Any_Of_Ctor_Params_Is_Null_Then_Throw_Exception(IRestClient client, NovaPoshtaConfig config)
        {
            ((Action)(() => new JsonLogic(client, config))).ShouldThrowExactly<ArgumentNullException>();
        }

        public static IEnumerable<TestCaseData> CtorParameters
        {
            get
            {
                var mockClient = new Mock<IRestClient>();

                yield return new TestCaseData(null, new InitialSetup().Config);
                yield return new TestCaseData(mockClient.Object, null);
            }
        }

    }
}
