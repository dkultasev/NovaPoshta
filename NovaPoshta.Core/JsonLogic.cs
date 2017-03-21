using System.Collections.Generic;
using RestSharp;

namespace NovaPoshta.Core
{
    public class JsonLogic
    {
        //private const string ApiKey = "fc6ccb0ad80b11ce020bdd6f97ecf28c";
        private string _apiKey;

        public JsonLogic()
        {
            _apiKey = new NovaPoshtaConfig().GetCfg().ApiKey;
        }

        public IEnumerable<RootObject<T>> GetObjectByRequest<T>(string modelName, string calledMethod, dynamic methodProperties)
        {
            var client = new RestClient($"http://testapi.novaposhta.ua/v2.0/json/{modelName}/{calledMethod}");
            var request = new RestRequest(Method.POST) { RequestFormat = DataFormat.Json };
            var jqr = new JsonRequestRoot()
            {
                apiKey = _apiKey,
                modelName = modelName,
                calledMethod = calledMethod,
                methodProperties = methodProperties
            };
            request.AddBody(jqr);
            request.OnBeforeDeserialization = resp => { resp.ContentType = "application/json"; };
            var result = client.Execute<List<RootObject<T>>>(request);
            if (result.StatusCode.IsSuccessStatusCode()) return result.Data;
            return result.Data;
        }
        public RootObject<T> GetObjectRootByRequest<T>(string modelName, string calledMethod, dynamic methodProperties)
        {
            var client = new RestClient($"http://testapi.novaposhta.ua/v2.0/json/{modelName}/{calledMethod}");
            var request = new RestRequest(Method.POST) { RequestFormat = DataFormat.Json };
            var jqr = new JsonRequestRoot()
            {
                apiKey = _apiKey,
                modelName = modelName,
                calledMethod = calledMethod,
                methodProperties = methodProperties

            };
            request.JsonSerializer = new RestSharpJsonNetSerializer();
            //var json = JsonConvert.SerializeObject(jqr);
            request.AddBody(jqr);
            request.OnBeforeDeserialization = resp => { resp.ContentType = "application/json"; };
            return client.Execute<RootObject<T>>(request).Data;
        }
        public IEnumerable<T> GetJsonData<T>(string modelName, string calledMethod, dynamic methodProperties)
        {
            var result = new JsonLogic().GetObjectByRequest<T>(modelName, calledMethod, methodProperties);
            return result[0].data;
        }

        public T GetJsonRootData<T>(string modelName, string calledMethod, dynamic methodProperties)
        {
            var result = new JsonLogic().GetObjectRootByRequest<T>(modelName, calledMethod, methodProperties);
            return result.data[0];
        }


    }
}
