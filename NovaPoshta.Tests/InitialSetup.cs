using System;
using System.IO;
using System.Reflection;
using Newtonsoft.Json;
using NovaPoshta.Json;

namespace NovaPoshta.Tests
{
    public class InitialSetup 
    {

        public NovaPoshtaConfig Config { get; set; }

        public InitialSetup()
        {
            SetCfg();
        }

        private void SetCfg()
        {
            string path = $"{Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)}\\cfg\\novaposhta.json";
            try
            {
                using (var r = new StreamReader(path))
                {
                    var json = r.ReadToEnd();
                    Config =  JsonConvert.DeserializeObject<NovaPoshtaConfig>(json);
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
