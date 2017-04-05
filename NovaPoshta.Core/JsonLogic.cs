using System;
using System.Collections.Generic;
using NLog;
using RestSharp;

namespace NovaPoshta.Core
{
    public class JsonLogic : IJsonLogic
    {
        private readonly string _apiKey;
        public readonly string ApiUrl = "https://api.novaposhta.ua/v2.0/json/";

        public JsonLogic()
        {
            _apiKey = new NovaPoshtaConfig().GetCfg().ApiKey;
        }

        public IEnumerable<T> GetJsonData<T>(string modelName, string calledMethod, dynamic methodProperties)
        {
            var result = new JsonLogic().GetObjectByRequest<T>(modelName, calledMethod, methodProperties);
            return result[0].data;
        }

        public T GetJsonRootData<T>(string modelName, string calledMethod, dynamic methodProperties)
        {
            var result = new JsonLogic().GetObjectRootByRequest<T>(modelName, calledMethod, methodProperties);
            if (result.errors?.Count > 0)
            {
                throw new ArgumentException(string.Join("\n", result.errors));
            }

            return result.data[0];
        }


        private IEnumerable<RootObject<T>> GetObjectByRequest<T>(string modelName, string calledMethod, dynamic methodProperties)
        {
            var client = new RestClient(ApiUrl);

            var request = new RestRequest(Method.POST) { RequestFormat = DataFormat.Json };
            var jqr = new JsonRequestRoot()
            {
                apiKey = _apiKey,
                modelName = modelName,
                calledMethod = calledMethod,
                methodProperties = methodProperties
            };
            request.JsonSerializer = new RestSharpJsonNetSerializer("yyyy-MM-dd HH:mm:ss");
            request.AddBody(jqr);
            request.OnBeforeDeserialization = resp => { resp.ContentType = "application/json"; };
            var result = client.Execute<List<RootObject<T>>>(request);
            if (result.StatusCode.IsSuccessStatusCode()) return result.Data;
            return result.Data;
        }

        private RootObject<T> GetObjectRootByRequest<T>(string modelName, string calledMethod, dynamic methodProperties)
        {
            var client = new RestClient(ApiUrl);

            var request = new RestRequest(Method.POST) { RequestFormat = DataFormat.Json };
            var jqr = new JsonRequestRoot()
            {
                apiKey = _apiKey,
                modelName = modelName,
                calledMethod = calledMethod,
                methodProperties = methodProperties

            };
            request.JsonSerializer = new RestSharpJsonNetSerializer("yyyy-MM-dd HH:mm:ss");
            request.AddBody(jqr);
            request.OnBeforeDeserialization = resp => { resp.ContentType = "application/json"; };
            var result = client.Execute<RootObject<T>>(request).Data;
            return result;
        }

    }
}
