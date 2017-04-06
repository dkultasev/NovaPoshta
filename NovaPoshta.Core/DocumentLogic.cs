using System;
using System.Collections.Generic;
using System.Linq;
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
            return _jsonLogic.GetJsonRootData<Document>("InternetDocument", "save", doc);
        }

        public Document GetDocumentByTTN(string ttn)
        {
            var properties = new { IntDocNumber = ttn};
            return GetDocuments(properties).FirstOrDefault();
        }

        private IEnumerable<Document> GetDocuments(dynamic properties)
        {
            var result = _jsonLogic.GetJsonData<Document>("InternetDocument", "getDocumentList", properties);
            return result;
        }

        public Document UpdateTTN(Document document)
        {
           return _jsonLogic.GetJsonRootData<Document>("InternetDocument", "update", document);
        }
    }
}
