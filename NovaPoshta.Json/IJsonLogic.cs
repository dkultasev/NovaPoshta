using System.Collections.Generic;

namespace NovaPoshta.Json
{
    public interface IJsonLogic
    {
        IEnumerable<T> GetListOfObjects<T>(string modelName, string calledMethod, dynamic methodProperties);
        T ModifyObject<T>(string modelName, string calledMethod, dynamic methodProperties);
    }
}