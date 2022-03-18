using System.Data.Entity.ModelConfiguration;
using WarehousesSystem.Models;

namespace WarehousesSystem.EntitiesConfigurations
{
    internal class ItemMeasureUnitConfiguration : EntityTypeConfiguration<ItemMeasureUnit>
    {
        public ItemMeasureUnitConfiguration()
        {
            HasKey(imu => new { imu.ItemCode, imu.MeasureUnit });
        }
    }
}
