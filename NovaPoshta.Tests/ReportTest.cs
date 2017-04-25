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
        private readonly IJsonLogic _jsonLogic = new JsonLogic(new RestClient(), new NovaPoshtaConfig().GetCfg());

        [Test]
        public void TestUnreceivedDocuments()
        {
            var rl = new Report();
            var dl= new DocumentLogic(_jsonLogic);
            DateTime start = new DateTime(2017, 1, 1);
            DateTime end = new DateTime(2017, 4, 1);
            var res = dl.GetDocumentsByDate(start, end);
            var result = rl.GetUnreceivedDocuments(res);
            int a = 0;
        }
    }
}
