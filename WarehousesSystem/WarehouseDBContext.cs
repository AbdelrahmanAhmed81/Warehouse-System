using System.Data.Entity;
using WarehousesSystem.Models;
using WarehousesSystem.EntitiesConfigurations;
namespace WarehouseSystem
{
    public class WarehouseDBContext : DbContext
    {
        public DbSet<Item> Items { get; set; }
        public DbSet<Warehouse> Warehouses { get; set; }
        public DbSet<WarehouseItem> WarehouseItems { get; set; }
        public DbSet<ItemMeasureUnit> ItemMeasureUnits { get; set; }
        public DbSet<Person> Persons { get; set; }
        public DbSet<Operation> Operations { get; set; }


        public WarehouseDBContext()
            : base("name=WarehouseSystem")
        {

        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Types().Configure(t => t.MapToStoredProcedures());
            modelBuilder.HasDefaultSchema("Main");

            modelBuilder.Configurations.Add(new ItemConfiguration());
            modelBuilder.Configurations.Add(new WarehouseConfiguration());
            modelBuilder.Configurations.Add(new WarehouseItemConfiguration());
            modelBuilder.Configurations.Add(new ItemMeasureUnitConfiguration());
            modelBuilder.Configurations.Add(new PersonConfiguration());
            modelBuilder.Configurations.Add(new CustomerConfiguration());
            modelBuilder.Configurations.Add(new SupplierConfiguration());
            modelBuilder.Configurations.Add(new OperationConfiguration());
            modelBuilder.Configurations.Add(new DemandConfiguration());
            modelBuilder.Configurations.Add(new SupplyConfiguration());
        }
    }

}