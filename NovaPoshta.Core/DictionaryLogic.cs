using System.Collections.Generic;
using System.Linq;
using NovaPoshta.Entity;

namespace NovaPoshta.Core
{
    public class DictionaryLogic
    {
        private readonly JsonLogic _jsonLogic;

        public DictionaryLogic()
        {
            _jsonLogic = new JsonLogic();
        }

        public IEnumerable<IDictionary> GetDictionary<IDictionary>(string dictionary, dynamic param = null)
        {
            return _jsonLogic.GetJsonData<IDictionary>("Common", "get" + dictionary, param);
        }

        public IEnumerable<PackList> GetPackList(PackList param = null)
        {
            return GetDictionary<PackList>(nameof(PackList), param);
        }
    }
}
