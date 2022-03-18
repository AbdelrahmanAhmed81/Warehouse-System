using System.Data.Entity.ModelConfiguration;
using WarehousesSystem.Models;

namespace WarehousesSystem.EntitiesConfigurations
{
    internal class ItemConfiguration:EntityTypeConfiguration<Item>
    {
        public ItemConfiguration()
        {
            HasKey(item => item.ItemCode);
            Property(item => item.Name).HasMaxLength(25).IsRequired();
        }
    }
}
