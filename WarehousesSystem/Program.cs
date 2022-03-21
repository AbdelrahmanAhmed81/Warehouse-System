using System;
using System.Windows.Forms;

namespace WarehousesSystem
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Home());
        }
    }
}
////warehouse data
//context.Warehouses.AddRange(new List<Warehouse>()
//{
//    new Warehouse(){WarehouseName="Cairo Inventory",Address="4S Ain Shams st, Cairo",ManagerName="Mohammed Ahmed"},
//    new Warehouse(){WarehouseName="Alex Inventory",Address="3A Seedy Bishr st, Alex",ManagerName="Gamal Mostafa"}
//});
////item data
//context.Items.AddRange(new List<Item>()
//{
//    new Item()
//    {
//        Name = "Pepsi",
//        MeasureUnits = new List<ItemMeasureUnit>()
//        {
//            new ItemMeasureUnit() { MeasureUnit = MeasureUnit.package }
//        }
//    },
//    new Item()
//    {
//        Name = "Oil",
//        MeasureUnits = new List<ItemMeasureUnit>()
//        {
//            new ItemMeasureUnit() { MeasureUnit = MeasureUnit.bottle }
//        }
//    },
//    new Item()
//    {
//        Name = "Sugar",
//        MeasureUnits = new List<ItemMeasureUnit>()
//        {
//            new ItemMeasureUnit() { MeasureUnit = MeasureUnit.kilogram },
//            new ItemMeasureUnit() { MeasureUnit = MeasureUnit.gram }
//        }
//    },
//    new Item()
//    {
//        Name = "Coca Cola",
//        MeasureUnits = new List<ItemMeasureUnit>()
//        {
//            new ItemMeasureUnit() { MeasureUnit = MeasureUnit.package }
//        }
//    }
//});
////supplier data
//context.Persons.AddRange(new List<Supplier>()
//{
//    new Supplier(){
//        Email="Cocacola@gmail.com",
//        Fax="+441619998888",
//        Name="Coca Cola",
//        PhoneNumber="+99154821641",
//        Telephone="+36465132",
//        WebsiteUrl="https://www.coca-cola.com"
//    },
//    new Supplier(){
//        Email="Crystal@gmail.com",
//        Fax="+994687122",
//        Name="Crystal",
//        PhoneNumber="+201015882214",
//        WebsiteUrl="https://www.crystal.com"
//    }
//});
////customer data
//context.Persons.AddRange(new List<Customer>()
//{
//    new Customer()
//    {
//        Email="Nestle@gmail.com",
//        Name="Nestle",
//        PhoneNumber="+495454871214",
//        WebsiteUrl="https://www.Nestle.com"
//    },
//    new Customer()
//    {
//        Email="KFC@gmail.com",
//        Name="KFC",
//        Fax="+01234568715264",
//        PhoneNumber="+415723571569",
//        WebsiteUrl="https://www.KFC.com"
//    },
//});
//demand data
//context.Operations.AddRange(new List<Demand>()
//{
//    new Demand()
//    {
//        WarehouseName = "Cairo Inventory",
//        ItemCode = 1007,
//        CustomerEmail ="KFC@gmail.com",
//        Quantity = 100,
//    },
//    new Demand()
//    {
//        WarehouseName = "Cairo Inventory",
//        ItemCode = 1009,
//        CustomerEmail ="KFC@gmail.com",
//        Quantity = 90,
//    },
//    new Demand()
//    {
//        WarehouseName = "Alex Inventory",
//        ItemCode = 1008,
//        CustomerEmail ="Nestle@gmail.com",
//        Quantity = 150,
//    },
//});
////supply data
//context.Operations.AddRange(new List<Supply>()
//{
//    new Supply()
//    {
//        WarehouseName = "Alex Inventory",
//        ItemCode = 1006,
//        SupplierEmail ="Crystal@gmail.com",
//        Quantity = 80,
//    },
//    new Supply()
//    {
//        WarehouseName = "Cairo Inventory",
//        ItemCode = 1006,
//        SupplierEmail ="Crystal@gmail.com",
//        Quantity = 110,
//    },
//    new Supply()
//    {
//        WarehouseName = "Alex Inventory",
//        ItemCode = 1009,
//        SupplierEmail ="Cocacola@gmail.com",
//        Quantity = 150,
//    },
//});
//context.SaveChanges();