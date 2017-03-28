using System;
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
    }
}
