namespace NovaPoshta.EF
{
    using System.Data.Entity;

    public class NovaPoshtaContext : DbContext
    {
        public NovaPoshtaContext()
            : base("name=NovaPoshtaContext")
        {
        }

        public virtual DbSet<Document> Documents { get; set; }
        public virtual DbSet<City> Cities { get; set; }
        public virtual DbSet<Warehouse> Warehouses { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Warehouse>()
                        .HasRequired<City>(s => s.Cities)
                        .WithMany(s => s.Warehouses)
                        .HasForeignKey(s => s.FK_CityRef);
        }
    }
}