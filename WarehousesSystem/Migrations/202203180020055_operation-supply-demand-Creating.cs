namespace WarehouseSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class operationsupplydemandCreating : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "Operation.Demands",
                c => new
                    {
                        Code = c.Guid(nullable: false),
                        ItemCode = c.Int(nullable: false),
                        WarehouseName = c.String(nullable: false, maxLength: 20),
                        Time = c.DateTime(nullable: false),
                        Quantity = c.Int(nullable: false),
                        CustomerEmail = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Code)
                .ForeignKey("Main.Items", t => t.ItemCode, cascadeDelete: true)
                .ForeignKey("Main.Warehouses", t => t.WarehouseName, cascadeDelete: true)
                .ForeignKey("Main.Customers", t => t.CustomerEmail)
                .Index(t => t.ItemCode)
                .Index(t => t.WarehouseName)
                .Index(t => t.CustomerEmail);
            
            CreateTable(
                "Operation.Supplies",
                c => new
                    {
                        Code = c.Guid(nullable: false),
                        ItemCode = c.Int(nullable: false),
                        WarehouseName = c.String(nullable: false, maxLength: 20),
                        Time = c.DateTime(nullable: false),
                        Quantity = c.Int(nullable: false),
                        SupplierEmail = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Code)
                .ForeignKey("Main.Items", t => t.ItemCode, cascadeDelete: true)
                .ForeignKey("Main.Warehouses", t => t.WarehouseName, cascadeDelete: true)
                .ForeignKey("Main.Suppliers", t => t.SupplierEmail)
                .Index(t => t.ItemCode)
                .Index(t => t.WarehouseName)
                .Index(t => t.SupplierEmail);
            
            CreateStoredProcedure(
                "Main.Demand_Insert",
                p => new
                    {
                        Code = p.Guid(),
                        ItemCode = p.Int(),
                        WarehouseName = p.String(maxLength: 20),
                        Time = p.DateTime(),
                        Quantity = p.Int(),
                        CustomerEmail = p.String(maxLength: 128),
                    },
                body:
                    @"INSERT [Operation].[Demands]([Code], [ItemCode], [WarehouseName], [Time], [Quantity], [CustomerEmail])
                      VALUES (@Code, @ItemCode, @WarehouseName, @Time, @Quantity, @CustomerEmail)"
            );
            
            CreateStoredProcedure(
                "Main.Demand_Update",
                p => new
                    {
                        Code = p.Guid(),
                        ItemCode = p.Int(),
                        WarehouseName = p.String(maxLength: 20),
                        Time = p.DateTime(),
                        Quantity = p.Int(),
                        CustomerEmail = p.String(maxLength: 128),
                    },
                body:
                    @"UPDATE [Operation].[Demands]
                      SET [ItemCode] = @ItemCode, [WarehouseName] = @WarehouseName, [Time] = @Time, [Quantity] = @Quantity, [CustomerEmail] = @CustomerEmail
                      WHERE ([Code] = @Code)"
            );
            
            CreateStoredProcedure(
                "Main.Demand_Delete",
                p => new
                    {
                        Code = p.Guid(),
                    },
                body:
                    @"DELETE [Operation].[Demands]
                      WHERE ([Code] = @Code)"
            );
            
            CreateStoredProcedure(
                "Main.Supply_Insert",
                p => new
                    {
                        Code = p.Guid(),
                        ItemCode = p.Int(),
                        WarehouseName = p.String(maxLength: 20),
                        Time = p.DateTime(),
                        Quantity = p.Int(),
                        SupplierEmail = p.String(maxLength: 128),
                    },
                body:
                    @"INSERT [Operation].[Supplies]([Code], [ItemCode], [WarehouseName], [Time], [Quantity], [SupplierEmail])
                      VALUES (@Code, @ItemCode, @WarehouseName, @Time, @Quantity, @SupplierEmail)"
            );
            
            CreateStoredProcedure(
                "Main.Supply_Update",
                p => new
                    {
                        Code = p.Guid(),
                        ItemCode = p.Int(),
                        WarehouseName = p.String(maxLength: 20),
                        Time = p.DateTime(),
                        Quantity = p.Int(),
                        SupplierEmail = p.String(maxLength: 128),
                    },
                body:
                    @"UPDATE [Operation].[Supplies]
                      SET [ItemCode] = @ItemCode, [WarehouseName] = @WarehouseName, [Time] = @Time, [Quantity] = @Quantity, [SupplierEmail] = @SupplierEmail
                      WHERE ([Code] = @Code)"
            );
            
            CreateStoredProcedure(
                "Main.Supply_Delete",
                p => new
                    {
                        Code = p.Guid(),
                    },
                body:
                    @"DELETE [Operation].[Supplies]
                      WHERE ([Code] = @Code)"
            );
            
        }
        
        public override void Down()
        {
            DropStoredProcedure("Main.Supply_Delete");
            DropStoredProcedure("Main.Supply_Update");
            DropStoredProcedure("Main.Supply_Insert");
            DropStoredProcedure("Main.Demand_Delete");
            DropStoredProcedure("Main.Demand_Update");
            DropStoredProcedure("Main.Demand_Insert");
            DropForeignKey("Operation.Supplies", "SupplierEmail", "Main.Suppliers");
            DropForeignKey("Operation.Supplies", "WarehouseName", "Main.Warehouses");
            DropForeignKey("Operation.Supplies", "ItemCode", "Main.Items");
            DropForeignKey("Operation.Demands", "CustomerEmail", "Main.Customers");
            DropForeignKey("Operation.Demands", "WarehouseName", "Main.Warehouses");
            DropForeignKey("Operation.Demands", "ItemCode", "Main.Items");
            DropIndex("Operation.Supplies", new[] { "SupplierEmail" });
            DropIndex("Operation.Supplies", new[] { "WarehouseName" });
            DropIndex("Operation.Supplies", new[] { "ItemCode" });
            DropIndex("Operation.Demands", new[] { "CustomerEmail" });
            DropIndex("Operation.Demands", new[] { "WarehouseName" });
            DropIndex("Operation.Demands", new[] { "ItemCode" });
            DropTable("Operation.Supplies");
            DropTable("Operation.Demands");
        }
    }
}
