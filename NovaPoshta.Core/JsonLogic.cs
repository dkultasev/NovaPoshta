using System;
using System.Collections.Generic;
using System.Text;
using NLog;
using RestSharp;

namespace NovaPoshta.Core
{
    public class JsonLogic
    {
        private readonly string _apiKey;
        public readonly string ApiUrl = "https://api.novaposhta.ua/v2.0/json/";
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();

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
            if (result.errors == null || result.errors.Count <= 0) return result.data[0];

            var message = string.Join("\n", result.errors);
            var e = new ArgumentException(message);

            Logger.Error(e);
            throw e;
        }


        private IEnumerable<RootObject<T>> GetObjectByRequest<T>(string modelName, string calledMethod, dynamic methodProperties)
        {
            //var client = new RestClient($"{_apiUrl}/{modelName}/json/{modelName}/{calledMethod}");
            var client = new RestClient(ApiUrl);
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

        private RootObject<T> GetObjectRootByRequest<T>(string modelName, string calledMethod, dynamic methodProperties)
        {
            //var client = new RestClient($"{_apiUrl}/json/{modelName}/{calledMethod}");
            var client = new RestClient(ApiUrl);
            var request = new RestRequest(Method.POST) { RequestFormat = DataFormat.Json };
            var jqr = new JsonRequestRoot()
            {
                apiKey = _apiKey,
                modelName = modelName,
                calledMethod = calledMethod,
                methodProperties = methodProperties

            };
            request.JsonSerializer = new RestSharpJsonNetSerializer();
            request.AddBody(jqr);
            request.OnBeforeDeserialization = resp => { resp.ContentType = "application/json"; };
            var result = client.Execute<RootObject<T>>(request).Data;
            return result;
        }
    }
}
