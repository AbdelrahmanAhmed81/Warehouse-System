namespace WarehouseSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class customersupplierCreating : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "Main.Customers",
                c => new
                    {
                        CustomerEmail = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 50),
                        PhoneNumber = c.String(nullable: false, maxLength: 13),
                        Fax = c.String(maxLength: 15),
                        WebsiteUrl = c.String(),
                        Telephone = c.String(maxLength: 10),
                    })
                .PrimaryKey(t => t.CustomerEmail);
            
            CreateTable(
                "Main.Suppliers",
                c => new
                    {
                        SupplierEmail = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 50),
                        PhoneNumber = c.String(nullable: false, maxLength: 13),
                        Fax = c.String(maxLength: 15),
                        WebsiteUrl = c.String(),
                        Telephone = c.String(maxLength: 10),
                    })
                .PrimaryKey(t => t.SupplierEmail);
            
            CreateStoredProcedure(
                "Main.Customer_Insert",
                p => new
                    {
                        CustomerEmail = p.String(maxLength: 128),
                        Name = p.String(maxLength: 50),
                        PhoneNumber = p.String(maxLength: 13),
                        Fax = p.String(maxLength: 15),
                        WebsiteUrl = p.String(),
                        Telephone = p.String(maxLength: 10),
                    },
                body:
                    @"INSERT [Main].[Customers]([CustomerEmail], [Name], [PhoneNumber], [Fax], [WebsiteUrl], [Telephone])
                      VALUES (@CustomerEmail, @Name, @PhoneNumber, @Fax, @WebsiteUrl, @Telephone)"
            );
            
            CreateStoredProcedure(
                "Main.Customer_Update",
                p => new
                    {
                        CustomerEmail = p.String(maxLength: 128),
                        Name = p.String(maxLength: 50),
                        PhoneNumber = p.String(maxLength: 13),
                        Fax = p.String(maxLength: 15),
                        WebsiteUrl = p.String(),
                        Telephone = p.String(maxLength: 10),
                    },
                body:
                    @"UPDATE [Main].[Customers]
                      SET [Name] = @Name, [PhoneNumber] = @PhoneNumber, [Fax] = @Fax, [WebsiteUrl] = @WebsiteUrl, [Telephone] = @Telephone
                      WHERE ([CustomerEmail] = @CustomerEmail)"
            );
            
            CreateStoredProcedure(
                "Main.Customer_Delete",
                p => new
                    {
                        CustomerEmail = p.String(maxLength: 128),
                    },
                body:
                    @"DELETE [Main].[Customers]
                      WHERE ([CustomerEmail] = @CustomerEmail)"
            );
            
            CreateStoredProcedure(
                "Main.Supplier_Insert",
                p => new
                    {
                        SupplierEmail = p.String(maxLength: 128),
                        Name = p.String(maxLength: 50),
                        PhoneNumber = p.String(maxLength: 13),
                        Fax = p.String(maxLength: 15),
                        WebsiteUrl = p.String(),
                        Telephone = p.String(maxLength: 10),
                    },
                body:
                    @"INSERT [Main].[Suppliers]([SupplierEmail], [Name], [PhoneNumber], [Fax], [WebsiteUrl], [Telephone])
                      VALUES (@SupplierEmail, @Name, @PhoneNumber, @Fax, @WebsiteUrl, @Telephone)"
            );
            
            CreateStoredProcedure(
                "Main.Supplier_Update",
                p => new
                    {
                        SupplierEmail = p.String(maxLength: 128),
                        Name = p.String(maxLength: 50),
                        PhoneNumber = p.String(maxLength: 13),
                        Fax = p.String(maxLength: 15),
                        WebsiteUrl = p.String(),
                        Telephone = p.String(maxLength: 10),
                    },
                body:
                    @"UPDATE [Main].[Suppliers]
                      SET [Name] = @Name, [PhoneNumber] = @PhoneNumber, [Fax] = @Fax, [WebsiteUrl] = @WebsiteUrl, [Telephone] = @Telephone
                      WHERE ([SupplierEmail] = @SupplierEmail)"
            );
            
            CreateStoredProcedure(
                "Main.Supplier_Delete",
                p => new
                    {
                        SupplierEmail = p.String(maxLength: 128),
                    },
                body:
                    @"DELETE [Main].[Suppliers]
                      WHERE ([SupplierEmail] = @SupplierEmail)"
            );
            
        }
        
        public override void Down()
        {
            DropStoredProcedure("Main.Supplier_Delete");
            DropStoredProcedure("Main.Supplier_Update");
            DropStoredProcedure("Main.Supplier_Insert");
            DropStoredProcedure("Main.Customer_Delete");
            DropStoredProcedure("Main.Customer_Update");
            DropStoredProcedure("Main.Customer_Insert");
            DropTable("Main.Suppliers");
            DropTable("Main.Customers");
        }
    }
}
