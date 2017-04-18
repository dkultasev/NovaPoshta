using System;
using System.Collections.Generic;
using NovaPoshta.Json;

namespace NovaPoshta.Core
{
    public class WarehouseLogic
    {
        private readonly IJsonLogic _jsonLogic;

        public WarehouseLogic(IJsonLogic jsonLogic)
        {
            if (jsonLogic == null) throw new ArgumentNullException(nameof(jsonLogic));
            _jsonLogic = jsonLogic;
        }
        public IEnumerable<Warehouse> GetWarehousesByCity(Guid cityRef)
        {
            return _jsonLogic.GetListOfObjects<Warehouse>("AddressGeneral", "getWarehouses",
             new { CityRef = cityRef });
        }
    }
}