using System;

namespace NovaPoshta.Json
{
    public interface INovaPoshtaConfig
    {
        string ApiKey { get; }
        Uri ApiUrl { get; }
    }
}