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

        [SetUp]
        public void Init()
        {
            _clientMock = new Mock<IRestClient>();
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
