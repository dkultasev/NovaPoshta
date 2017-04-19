﻿using System;
using System.Collections.Generic;
using System.Linq;
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

        public RootObject<T> GetListOfObjects<T>(string modelName, string calledMethod, dynamic methodProperties)
        {
            var request = PrepareRequest(modelName, calledMethod, methodProperties);
            IRestResponse<List<RootObject<T>>> result = _client.Execute<List<RootObject<T>>>(request);
            return result.Data[0];
        }

        public T ModifyObject<T>(string modelName, string calledMethod, dynamic methodProperties)
        {
            var request = PrepareRequest(modelName, calledMethod, methodProperties);
            RootObject<T> result = _client.Execute<RootObject<T>>(request).Data;
            if (result.errors?.Count > 0)
            {
                throw new ResponseException(result.errors.Select(x => x.ToString()).ToList());
            }

            return result.data[0];
        }

        private IRestRequest PrepareRequest(string modelName, string calledMethod, dynamic methodProperties)
        {
            var jqr = new JsonRequestRoot()
            {
                apiKey = _config.ApiKey,
                modelName = modelName,
                calledMethod = calledMethod,
                methodProperties = methodProperties

            };

            _client.BaseUrl = _config.ApiUrl;
            IRestRequest request = new RestRequest(Method.POST) { RequestFormat = DataFormat.Json };
            request.JsonSerializer = new RestSharpJsonNetSerializer("yyyy-MM-dd HH:mm:ss");
            request.AddBody(jqr);
            request.OnBeforeDeserialization = resp => { resp.ContentType = "application/json"; };
            return request;
        }

    }
}
