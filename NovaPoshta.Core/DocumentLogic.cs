﻿using System;
using System.Collections.Generic;
using System.Linq;
using NovaPoshta.Core.Entities;
using NovaPoshta.Json;

namespace NovaPoshta.Core
{
    public class DocumentLogic
    {
        private readonly IJsonLogic _jsonLogic;

        public DocumentLogic(IJsonLogic jsonLogic)
        {
            if (jsonLogic == null) throw new ArgumentNullException(nameof(jsonLogic));
            _jsonLogic = jsonLogic;
        }
        public Document CreateInternetDocument(Document doc)
        {
            return _jsonLogic.ModifyObject<Document>("InternetDocument", "save", doc);
        }

        public Document GetDocumentByTTN(string ttn)
        {
            var properties = new { IntDocNumber = ttn};
            return GetDocuments(properties).FirstOrDefault();
        }

        public IEnumerable<Document> GetDocumentsByDate(DateTime dateFrom, DateTime? dateTo = null)
        {
            dynamic prop;
            if (dateTo.HasValue)
            {
                prop = new
                {
                    DateTimeFrom = dateFrom.ToString("dd.MM.yyyy"),
                    DateTimeTo = dateTo.Value.ToString("dd.MM.yyyy")
                };
            }
            else
            {
                prop = new
                {
                    DateTime = dateFrom.ToString("dd.MM.yyyy")
                };
            }
            return GetDocuments(prop);
        }

        public IEnumerable<Document> GetStatusDocuments(IEnumerable<Document> documents)
        {
            var docs = new
            {
                Documents = documents.Select(x => new
                {
                    DocumentNumber = x.IntDocNumber,
                    Phone = x.RecipientsPhone
                }).ToList()

            };

            var result = _jsonLogic.GetListOfObjects<Document>("TrackingDocument", "getStatusDocuments", docs).data;
            return result;
        }

        private IEnumerable<Document> GetDocuments(dynamic properties)
        {
            var result = _jsonLogic.GetListOfObjects<Document>("InternetDocument", "getDocumentList", properties).data;
            return result;
        }

        public Document UpdateTTN(Document document)
        {
           return _jsonLogic.ModifyObject<Document>("InternetDocument", "update", document);
        }
    }
}
