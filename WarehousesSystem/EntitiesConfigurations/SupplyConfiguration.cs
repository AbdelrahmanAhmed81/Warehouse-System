using System.Data.Entity.ModelConfiguration;
using WarehousesSystem.Models;

namespace WarehousesSystem.EntitiesConfigurations
{
    internal class SupplyConfiguration : EntityTypeConfiguration<Supply>
    {
        public SupplyConfiguration()
        {
            Property(operation => operation.ProductionDate).HasColumnType("date").IsRequired();
            Property(operation => operation.ExpireDays).IsRequired();
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
