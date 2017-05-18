using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NovaPoshta.EF
{
    public class Warehouse
    {
        [Key]
        public Guid Ref { get; set; }
        public string Description { get; set; }
        public string DescriptionRu { get; set; }
        public string Phone { get; set; }
        public Guid TypeOfWarehouse { get; set; }
        public int Number { get; set; }
        public Guid CityRef { get; set; }
        [ForeignKey("CityRef")]
        public City City { get; set; }
        public City Cities { get; set; }
    }
}
