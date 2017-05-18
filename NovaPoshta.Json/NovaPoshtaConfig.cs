using System;

namespace NovaPoshta.Json
{
    public class NovaPoshtaConfig : INovaPoshtaConfig
    {
        public string ApiKey { get; }
        public Uri ApiUrl { get; }

        public NovaPoshtaConfig(string apiKey, Uri apiUrl)
        {
            if (apiKey == null) throw new ArgumentNullException(nameof(apiKey));
            if (apiUrl == null) throw new ArgumentNullException(nameof(apiUrl));

            ApiKey = apiKey;
            ApiUrl = apiUrl;
        }
    }
}
