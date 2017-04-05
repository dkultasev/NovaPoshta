using System;
using System.Linq;
using NovaPoshta.Core;
using NUnit.Framework;

namespace NovaPoshta.Tests
{
    internal class CityTest
    {
        private readonly IJsonLogic _jsonLogic = new JsonLogic();

        [Test]
        public void GetAllCitiesTest()
        {
            var cl = new CityLogic(_jsonLogic);
            var result = cl.GetAllCities().Count(); 
            Assert.Greater(result, 1000);
        }

        [Test]
        public void GetCityByRefTest()
        {
            var cl = new CityLogic(_jsonLogic);
            var city = cl.GetCityByRef(new Guid("ebc0eda9-93ec-11e3-b441-0050568002cf"));
            Assert.AreEqual(city.FirstOrDefault().DescriptionRu, "Агрономичное");
        }

        [Test]
        public void GetCityByNameTest()
        {
            var cl = new CityLogic(_jsonLogic);
            var city = cl.GetCityByName("Одесса");
            Assert.AreEqual(city.DescriptionRu, "Одесса");
        }
    }
}
