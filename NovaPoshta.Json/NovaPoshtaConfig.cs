using System;
using System.IO;
using System.Reflection;
using Newtonsoft.Json;

namespace NovaPoshta.Json
{
    public class NovaPoshtaConfig
    {
        public string ApiKey { get; set; }
        public Uri ApiUrl { get; set; }

        public NovaPoshtaConfig GetCfg()
        {
            string path = $"{Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)}\\cfg\\novaposhta.json";
            try
            {
                using (var r = new StreamReader(path))
                {   
                    var json = r.ReadToEnd();
                    return JsonConvert.DeserializeObject<NovaPoshtaConfig>(json);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}
