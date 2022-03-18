using System.Data.Entity.ModelConfiguration;
using WarehousesSystem.Models;

namespace WarehousesSystem.EntitiesConfigurations
{
    internal class OperationConfiguration : EntityTypeConfiguration<Operation>
    {
        public OperationConfiguration()
        {
           HasKey(operation => operation.Code);
           Property(operation => operation.Quantity).IsRequired();
           Property(operation => operation.WarehouseName).IsRequired();
           Property(operation => operation.ItemCode).IsRequired();
        }
    }
}
