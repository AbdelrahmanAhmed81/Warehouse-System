using System.Data.Entity.ModelConfiguration;
using WarehousesSystem.Models;

namespace WarehousesSystem.EntitiesConfigurations
{
    internal class CustomerConfiguration : EntityTypeConfiguration<Customer>
    {
        public CustomerConfiguration()
        {
            Map(m =>
            {
                m.MapInheritedProperties();
                m.ToTable("Customers");
                m.Property(customer => customer.Email).HasColumnName("CustomerEmail");
            });
        }
    }
}
