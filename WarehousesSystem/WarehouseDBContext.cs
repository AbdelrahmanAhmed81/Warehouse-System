using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using WarehousesSystem.Models;

namespace WarehouseSystem
{
    public class WarehouseDBContext : DbContext
    {
        public DbSet<Item> Items { get; set; }
        public DbSet<Warehouse> Warehouses { get; set; }
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
            //tables properties configuration

            //Item Configuration
            modelBuilder.Entity<Item>().HasKey(item => item.ItemCode);
            modelBuilder.Entity<Item>().Property(item => item.Name).HasMaxLength(25).IsRequired();


            //Warehouse Configuration
            modelBuilder.Entity<Warehouse>().HasKey(warehouse => warehouse.WarehouseName);
            modelBuilder.Entity<Warehouse>().Property(warehouse => warehouse.WarehouseName).HasMaxLength(20);
            modelBuilder.Entity<Warehouse>().Property(warehouse => warehouse.Address).HasMaxLength(50).IsRequired();
            modelBuilder.Entity<Warehouse>().Property(warehouse => warehouse.ManagerName).HasMaxLength(50);

            //ItemMeasureUnit Configuration
            modelBuilder.Entity<ItemMeasureUnit>().HasKey(imu => new { imu.ItemCode, imu.MeasureUnit });

            //Persons Configuration
            modelBuilder.Entity<Person>().HasKey(person => person.Email);
            modelBuilder.Entity<Person>().Property(person => person.Name).HasMaxLength(50).IsRequired();
            modelBuilder.Entity<Person>().Property(person => person.PhoneNumber).HasMaxLength(13).IsRequired();
            modelBuilder.Entity<Person>().Property(person => person.Fax).HasMaxLength(15);
            modelBuilder.Entity<Person>().Property(person => person.Telephone).HasMaxLength(10);

            modelBuilder.Entity<Customer>().Map(m =>
            {
                m.MapInheritedProperties();
                m.ToTable("Customers");
                m.Property(customer => customer.Email).HasColumnName("CustomerEmail");
            });

            modelBuilder.Entity<Supplier>().Map(m =>
            {
                m.MapInheritedProperties();
                m.ToTable("Suppliers");
                m.Property(supplier => supplier.Email).HasColumnName("SupplierEmail");
            });

            //Operation Configuration
            modelBuilder.Entity<Operation>().HasKey(operation => operation.Code);
            modelBuilder.Entity<Operation>().Property(operation => operation.Quantity).IsRequired();
            modelBuilder.Entity<Operation>().Property(operation => operation.WarehouseName).IsRequired();
            modelBuilder.Entity<Operation>().Property(operation => operation.ItemCode).IsRequired();

            modelBuilder.Entity<Demand>().Map(m =>
            {
                m.MapInheritedProperties();
                m.ToTable("Demands", "Operation");
            });
            modelBuilder.Entity<Demand>().HasRequired(demand => demand.Customer)
                .WithMany(customer => customer.Demands)
                .HasForeignKey(demand => demand.CustomerEmail);

            modelBuilder.Entity<Supply>().Map(m =>
            {
                m.MapInheritedProperties();
                m.ToTable("Supplies", "Operation");
            });
            modelBuilder.Entity<Supply>().HasRequired(supply => supply.Supplier)
                .WithMany(supplier => supplier.Supplies)
                .HasForeignKey(supply => supply.SupplierEmail);

        }
    }

}