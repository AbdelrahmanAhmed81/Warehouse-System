using System.Data.Entity.ModelConfiguration;
using WarehousesSystem.Models;

namespace WarehousesSystem.EntitiesConfigurations
{
    internal class WarehouseItemConfiguration : EntityTypeConfiguration<WarehouseItem>
    {
        public WarehouseItemConfiguration()
        {
            HasKey(wi => new {wi.WarehouseName,wi.ItemCode});
            Property(wi => wi.Quantity).IsRequired();
        }
    }
}
