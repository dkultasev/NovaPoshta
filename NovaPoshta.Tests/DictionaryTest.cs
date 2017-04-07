using System.Linq;
using NovaPoshta.Core;
using NovaPoshta.Entity;
using NovaPoshta.Json;
using NUnit.Framework;
using RestSharp;

namespace NovaPoshta.Tests
{
    public class DictionaryTest
    {
        private readonly IJsonLogic _jsonLogic = new JsonLogic(new RestClient(), new NovaPoshtaConfig().GetCfg().ApiKey);

        [Test]
        public void GetTypesOfPayersTest()
        {
            var dl = new DictionaryLogic(_jsonLogic);
            var result = dl.GetDictionary<Dictionary>("TypesOfPayers");
            Assert.Greater(result.Count(), 1);
        }

        [Test]
        public void GetPackListTest()
        {
            var dl = new DictionaryLogic(_jsonLogic);
            var result = dl.GetPackList();
            Assert.Greater(result.Count(), 1);
        }

        [Test]
        public void GetPackListWithWidth1000Test()
        {
            var dl = new DictionaryLogic(_jsonLogic);
            var result = dl.GetPackList(new PackList() { Width = 1000});
            Assert.AreEqual(result.FirstOrDefault().Width, 1000);
        }
    }
}
