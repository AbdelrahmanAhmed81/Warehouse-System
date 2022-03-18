using System.Data.Entity.ModelConfiguration;
using WarehousesSystem.Models;

namespace WarehousesSystem.EntitiesConfigurations
{
    internal class DemandConfiguration : EntityTypeConfiguration<Demand>
    {
        public DemandConfiguration()
        {
            Map(m =>
            {
                m.MapInheritedProperties();
                m.ToTable("Demands", "Operation");
            });
            HasRequired(demand => demand.Customer)
                .WithMany(customer => customer.Demands)
                .HasForeignKey(demand => demand.CustomerEmail);
        }
    }
}
