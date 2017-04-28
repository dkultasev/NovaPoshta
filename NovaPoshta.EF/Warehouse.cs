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
        public Guid FK_CityRef { get; set; }
        [ForeignKey("FK_CityRef")]
        public City City { get; set; }
        public City Cities { get; set; }
    }
}
