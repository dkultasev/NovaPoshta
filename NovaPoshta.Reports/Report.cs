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
        private readonly IJsonLogic _jsonLogic;

        public Report(IJsonLogic jsonLogic)
        {
            if (jsonLogic == null) throw new ArgumentNullException(nameof(jsonLogic));
            _jsonLogic = jsonLogic;
        }

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
            //}

        }
    }
}
