namespace NovaPoshta.Entity
{
    public class PackList : Dictionary
    {
        public decimal Length { get; set; }
        public decimal Width { get; set; }
        public decimal Height { get; set; }
        public string TypeOfPacking { get; set; }
    }
}
