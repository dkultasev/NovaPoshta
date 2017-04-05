using System;
using System.Collections.Generic;
using NovaPoshta.Core;
using NovaPoshta.Entity;
using NUnit.Framework;

namespace NovaPoshta.Tests
{
    public class WarehouseTest
    {
        private readonly IJsonLogic _jsonLogic = new JsonLogic(new NovaPoshtaConfig().GetCfg().ApiKey);

        [Test]
        public void GetWarehouseByCityRefTest()
        {
            var wl = new WarehouseLogic(_jsonLogic);
            var results = wl.GetWarehousesByCity(new Guid("ebc0eda9-93ec-11e3-b441-0050568002cf")) as ICollection<Warehouse>;

            Assert.AreEqual(results.Count, 1);
        }
    }
}
