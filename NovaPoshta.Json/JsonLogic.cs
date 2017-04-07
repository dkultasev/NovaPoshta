﻿using System;
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
            var result = GetObjectByRequest<T>(modelName, calledMethod, methodProperties);
            return result[0].data;
        }

        public T GetJsonRootData<T>(string modelName, string calledMethod, dynamic methodProperties)
        {
            var result = GetObjectRootByRequest<T>(modelName, calledMethod, methodProperties);
            if (result.errors?.Count > 0)
            {
                throw new ArgumentException(string.Join("\n", result.errors));
            }

            return result.data[0];
        }


        private IEnumerable<RootObject<T>> GetObjectByRequest<T>(string modelName, string calledMethod, dynamic methodProperties)
        {
            _client.BaseUrl = _config.ApiUrl; 

            var request = new RestRequest(Method.POST) { RequestFormat = DataFormat.Json };
            var jqr = new JsonRequestRoot()
            {
                apiKey = _config.ApiKey,
                modelName = modelName,
                calledMethod = calledMethod,
                methodProperties = methodProperties
            };
            request.JsonSerializer = new RestSharpJsonNetSerializer("yyyy-MM-dd HH:mm:ss");
            request.AddBody(jqr);
            request.OnBeforeDeserialization = resp => { resp.ContentType = "application/json"; };
            var result = _client.Execute<List<RootObject<T>>>(request);
            return result.Data;
        }

        private RootObject<T> GetObjectRootByRequest<T>(string modelName, string calledMethod, dynamic methodProperties)
        {
            _client.BaseUrl = _config.ApiUrl;

            var request = new RestRequest(Method.POST) { RequestFormat = DataFormat.Json };
            var jqr = new JsonRequestRoot()
            {
                apiKey = _config.ApiKey,
                modelName = modelName,
                calledMethod = calledMethod,
                methodProperties = methodProperties

            };
            request.JsonSerializer = new RestSharpJsonNetSerializer("yyyy-MM-dd HH:mm:ss");
            request.AddBody(jqr);
            request.OnBeforeDeserialization = resp => { resp.ContentType = "application/json"; };
            var result = _client.Execute<RootObject<T>>(request).Data;
            return result;
        }

    }
}
