using System;
using System.Collections.Generic;
using NovaPoshta.Entity;

namespace NovaPoshta.Core
{
    public class DictionaryLogic
    {
        private readonly IJsonLogic _jsonLogic;

        public DictionaryLogic(IJsonLogic jsonLogic)
        {
            if (jsonLogic == null) throw new ArgumentNullException(nameof(jsonLogic));
            _jsonLogic = jsonLogic;
        }

        public IEnumerable<T> GetDictionary<T>(string dictionary, dynamic param = null)
        {
            return _jsonLogic.GetJsonData<T>("Common", "get" + dictionary, param);
        }

        public IEnumerable<PackList> GetPackList(PackList param = null)
        {
            return GetDictionary<PackList>(nameof(PackList), param);
        }
    }
}
