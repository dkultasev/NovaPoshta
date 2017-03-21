using System;
using System.Collections.Generic;
using NovaPoshta.Entity;

namespace NovaPoshta.Core
{
    public class WarehouseLogic
    {
        private readonly JsonLogic _jsonLogic;
        public WarehouseLogic()
        {
            _jsonLogic = new JsonLogic();
        }
        public IEnumerable<Warehouse> GetWarehousesByCity(Guid cityRef)
        {
            return _jsonLogic.GetJsonData<Warehouse>("AddressGeneral", "getWarehouses",
             new { CityRef = cityRef });
        }
    }
}