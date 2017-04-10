using System;
using System.Collections.Generic;
using RestSharp;

namespace NovaPoshta.Json
{
    public class JsonLogic : IJsonLogic
    {
        private readonly IRestClient _client;
        private readonly NovaPoshtaConfig _config;

        public JsonLogic(IRestClient client, NovaPoshtaConfig config)
        {
            if (client == null) throw new ArgumentNullException(nameof(client));
            if (config == null) throw new ArgumentNullException(nameof(config));
            _client = client;
            _config = config;
        }

        public IEnumerable<T> GetJsonData<T>(string modelName, string calledMethod, dynamic methodProperties)
        {
            var jqr = new JsonRequestRoot()
            {
                apiKey = _config.ApiKey,
                modelName = modelName,
                calledMethod = calledMethod,
                methodProperties = methodProperties
            };

            dynamic result = GetObjectByRequest<T>(jqr);
            return result[0].data;
        }

        public T GetJsonRootData<T>(string modelName, string calledMethod, dynamic methodProperties)
        {
            var jqr = new JsonRequestRoot()
            {
                apiKey = _config.ApiKey,
                modelName = modelName,
                calledMethod = calledMethod,
                methodProperties = methodProperties

            };
            RootObject<T> result = GetObjectRootByRequest<T>(jqr);
            if (result.errors?.Count > 0)
            {
                throw new ArgumentException(string.Join("\n", result.errors));
            }

            return result.data[0];
        }


        private IEnumerable<RootObject<T>> GetObjectByRequest<T>(JsonRequestRoot jqr)
        {
            _client.BaseUrl = _config.ApiUrl;

            var request = new RestRequest(Method.POST)
            {
                RequestFormat = DataFormat.Json,
                JsonSerializer = new RestSharpJsonNetSerializer("yyyy-MM-dd HH:mm:ss")
            };

            request.AddBody(jqr);
            request.OnBeforeDeserialization = resp => { resp.ContentType = "application/json"; };
            var result = _client.Execute<List<RootObject<T>>>(request);
            return result.Data;
        }

        private RootObject<T> GetObjectRootByRequest<T>(JsonRequestRoot jqr)
        {
            var request = PrepareRequest(jqr);
            var result = _client.Execute<RootObject<T>>(request).Data;
            return result;
        }

        private IRestRequest PrepareRequest(JsonRequestRoot jqr)
        {
            _client.BaseUrl = _config.ApiUrl;
            IRestRequest request = new RestRequest(Method.POST) { RequestFormat = DataFormat.Json };
            request.JsonSerializer = new RestSharpJsonNetSerializer("yyyy-MM-dd HH:mm:ss");
            request.AddBody(jqr);
            request.OnBeforeDeserialization = resp => { resp.ContentType = "application/json"; };
            return request;
        }

    }
}
