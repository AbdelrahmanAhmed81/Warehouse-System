using System.Data.Entity.ModelConfiguration;
using WarehousesSystem.Models;

namespace WarehousesSystem.EntitiesConfigurations
{
    internal class SupplierConfiguration : EntityTypeConfiguration<Supplier>
    {
        public SupplierConfiguration()
        {
            Map(m =>
            {
                m.MapInheritedProperties();
                m.ToTable("Suppliers");
                m.Property(supplier => supplier.Email).HasColumnName("SupplierEmail");
            });
        }
    }
}
