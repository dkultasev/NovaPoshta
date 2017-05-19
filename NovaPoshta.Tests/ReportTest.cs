using System;
using NovaPoshta.Core;
using NovaPoshta.Json;
using NUnit.Framework;
using RestSharp;
using NovaPoshta.Reports;

namespace NovaPoshta.Tests
{
    public class ReportTest
    {
        private readonly IJsonLogic _jsonLogic = new JsonLogic(new RestClient(), new InitialSetup().Config);

        [Test]
        public void TestUnreceivedDocuments()
        {
            var rl = new Report(_jsonLogic);
            var dl= new DocumentLogic(_jsonLogic);
            DateTime start = new DateTime(2017, 1, 1);
            DateTime end = new DateTime(2017, 5, 19);
            var res = dl.GetDocumentsByDate(start, end);
            var result = rl.GetUnreceivedDocuments(res);
            int a = 0;
        }
    }
}
