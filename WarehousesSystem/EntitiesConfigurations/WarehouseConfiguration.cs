using System.Data.Entity.ModelConfiguration;
using WarehousesSystem.Models;

namespace WarehousesSystem.EntitiesConfigurations
{
    internal class WarehouseConfiguration:EntityTypeConfiguration<Warehouse>
    {
        public WarehouseConfiguration()
        {
            HasKey(warehouse => warehouse.WarehouseName);
            Property(warehouse => warehouse.WarehouseName).HasMaxLength(20);
            Property(warehouse => warehouse.Address).HasMaxLength(50).IsRequired();
            Property(warehouse => warehouse.ManagerName).HasMaxLength(50);
        }
    }
}
