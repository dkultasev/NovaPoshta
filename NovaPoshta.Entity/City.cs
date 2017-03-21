using System;

namespace NovaPoshta.Entity
{
    public class City
    {
        public Guid Ref { get; set; }
        public string Description { get; set; }
        public string DescriptionRu { get; set; }
        public int Delivery1 { get; set; }
        public int Delivery2 { get; set; }
        public int Delivery3 { get; set; }
        public int Delivery4 { get; set; }
        public int Delivery5 { get; set; }
        public int Delivery6 { get; set; }
        public int Delivery7 { get; set; }
        public Guid Area { get; set; }
        public int? CityId { get; set; }
    }
}
