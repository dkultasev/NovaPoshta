using System.Collections.Generic;

namespace NovaPoshta.Core
{
    public interface IJsonLogic
    {
        IEnumerable<T> GetJsonData<T>(string modelName, string calledMethod, dynamic methodProperties);
        T GetJsonRootData<T>(string modelName, string calledMethod, dynamic methodProperties);
    }
}