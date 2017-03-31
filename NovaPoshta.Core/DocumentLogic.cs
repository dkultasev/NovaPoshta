using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NovaPoshta.Core
{
    public class DocumentLogic
    {
        private readonly JsonLogic _jsonLogic;

        public DocumentLogic()
        {
            _jsonLogic = new JsonLogic();
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
    }
}
