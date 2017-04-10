using System.Linq;
using System.Net;
using Moq;
using NovaPoshta.Core;
using NovaPoshta.Entity;
using NovaPoshta.Json;
using NUnit.Framework;
using RestSharp;

namespace NovaPoshta.Tests
{
    public class RestClientTests
    {
        [Test]
        public void When_SimpleRequest_Then_StatusOK()
        {
            Mock<IRestClient> mockClient = new Mock<IRestClient>();

            mockClient.Setup(x => x.Execute<Document>(It.IsAny<IRestRequest>())).Returns(new RestResponse<Document>()
            {
                StatusCode = HttpStatusCode.OK,
                Content = null
            });

            mockClient.Object.ExecuteAsync(new RestRequest(), (response, handle) =>
            {
                Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            });
        }
    }
}
