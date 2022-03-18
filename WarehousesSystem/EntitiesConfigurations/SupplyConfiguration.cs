using System.Data.Entity.ModelConfiguration;
using WarehousesSystem.Models;

namespace WarehousesSystem.EntitiesConfigurations
{
    internal class SupplyConfiguration : EntityTypeConfiguration<Supply>
    {
        public SupplyConfiguration()
        {
            Map(m =>
            {
                m.MapInheritedProperties();
                m.ToTable("Supplies", "Operation");
            });
            HasRequired(supply => supply.Supplier)
                .WithMany(supplier => supplier.Supplies)
                .HasForeignKey(supply => supply.SupplierEmail);
        }
    }
}
