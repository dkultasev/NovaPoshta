using System.Data.Entity.Core.Objects;
using System.Data.Entity.Infrastructure;

namespace NovaPoshta.EF
{
    using System.Data.Entity;

    public class NovaPoshtaContext : DbContext
    {
        public NovaPoshtaContext()
            : base("name=NovaPoshtaContext")
        {
        }
        public ObjectContext ObjectContext()
        {
            return (this as IObjectContextAdapter).ObjectContext;
        }

        public virtual DbSet<Document> Documents { get; set; }
        public virtual DbSet<City> Cities { get; set; }
        public virtual DbSet<Warehouse> Warehouses { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Warehouse>()
                        .HasRequired(s => s.Cities)
                        .WithMany(s => s.Warehouses)
                        .HasForeignKey(s => s.CityRef);
        }
    }
}