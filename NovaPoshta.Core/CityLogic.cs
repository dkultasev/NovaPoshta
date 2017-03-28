using System;
using System.Collections.Generic;
using NovaPoshta.Entity;

namespace NovaPoshta.Core
{
    public class CityLogic
    {
        private readonly JsonLogic _jsonLogic;

        public CityLogic()
        {
            _jsonLogic = new JsonLogic();
        }


        public IEnumerable<City> GetAllCities()
        {
            return _jsonLogic.GetJsonData<City>("Address", "getCities", new { });
        }

        public IEnumerable<City> GetCityByRef(Guid cityRef)
        {
            return _jsonLogic.GetJsonData<City>("Address", "getCities", new {Ref = cityRef});
        }
        public IEnumerable<City> GetCityByName(string cityName)
        {
            return _jsonLogic.GetJsonData<City>("Address", "getCities", new { FindByString = cityName });
        }
    }
}
