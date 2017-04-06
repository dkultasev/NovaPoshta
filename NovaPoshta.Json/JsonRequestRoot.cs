namespace NovaPoshta.Json
{
    public class JsonRequestRoot
    {
        public string apiKey { get; set; }
        public string modelName { get; set; }
        public string calledMethod { get; set; }
        public dynamic methodProperties { get; set; }
    }
}
