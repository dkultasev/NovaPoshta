using System;
using System.Collections.Generic;
using System.Linq;
using NovaPoshta.Core.Entities;
using NovaPoshta.Json;

namespace NovaPoshta.Core
{
    public class CityLogic
    {
        private readonly IJsonLogic _jsonLogic;

        public CityLogic(IJsonLogic jsonLogic)
        {
            if (jsonLogic == null) throw new ArgumentNullException(nameof(jsonLogic));
            _jsonLogic = jsonLogic;
        }

        public IEnumerable<City> GetAllCities()
        {
           return _jsonLogic.GetListOfObjects<City>("Address", "getCities", new { });
        }

        public IEnumerable<City> GetCityByRef(Guid cityRef)
        {
            return _jsonLogic.GetListOfObjects<City>("Address", "getCities", new {Ref = cityRef});
        }
        public City GetCityByName(string cityName)
        {
            return _jsonLogic.GetListOfObjects<City>("Address", "getCities", new { FindByString = cityName }).FirstOrDefault();
        }
    }
}
