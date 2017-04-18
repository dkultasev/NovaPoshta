using System;

namespace NovaPoshta.Core.Entities
{ 
        public class Warehouse
        {
            public Guid Ref { get; set; }
            public string Description { get; set; }
            public string DescriptionRu { get; set; }
            public string Phone { get; set; }
            public Guid TypeOfWarehouse { get; set; }
            public int Number { get; set; }
            public Guid CityRef { get; set; }
            public  City Cities { get; set; }

        }
}
