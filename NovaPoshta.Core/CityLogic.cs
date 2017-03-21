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

        public IEnumerable<City> GetCity(dynamic methodProperties)
        {
            return _jsonLogic.GetJsonData<City>("Address", "getCities", methodProperties);
        }
    }
}
