using System;
using System.Collections.Generic;
using System.Linq;
using NovaPoshta.Core;
using NovaPoshta.Entity;
using NUnit.Framework;

namespace NovaPoshta.Tests
{
    class CityTest
    {
        //[Ignore("not for every run")]
        [Test]

        public void GetAllCitiesTest()
        {
            var cl = new CityLogic();
            var result = cl.GetAllCities().Count(); 
            Assert.Greater(result, 1000);
        }

        [Test]
        public void GetCityByRefTest()
        {
            var cl = new CityLogic();
            var city = cl.GetCity(new { Ref = new Guid("ebc0eda9-93ec-11e3-b441-0050568002cf") });
            Assert.AreEqual(city.FirstOrDefault().DescriptionRu, "Агрономичное");
        }
    }
}
