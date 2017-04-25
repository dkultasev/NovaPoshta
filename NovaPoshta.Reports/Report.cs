using System;
using System.Collections.Generic;
using NovaPoshta.Core;
using NovaPoshta.Core.Entities;
using NovaPoshta.Json;
using RestSharp;

namespace NovaPoshta.Reports
{
    public class Report : IReport
    {
        private readonly IJsonLogic _jsonLogic = new JsonLogic(new RestClient(), new NovaPoshtaConfig().GetCfg());
        public IEnumerable<Document> GetUnreceivedDocuments(IEnumerable<Document> documents)
        {
            var allDocuments = new DocumentLogic(_jsonLogic).GetStatusDocuments(documents);
            foreach (var doc in allDocuments)
            {
                int a = 0;
            }
            
            //var unReceived = from document in allDocuments
            //                 where document.StateId
            return allDocuments;
        }
    }
}
