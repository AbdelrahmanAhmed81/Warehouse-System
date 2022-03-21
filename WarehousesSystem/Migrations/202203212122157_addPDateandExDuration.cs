namespace WarehouseSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addPDateandExDuration : DbMigration
    {
        public override void Up()
        {
            AddColumn("Operation.Demands", "ProductionDate", c => c.DateTime(nullable: false, storeType: "date"));
            AddColumn("Operation.Demands", "ExpireDuration", c => c.Int(nullable: false));
            AddColumn("Operation.Supplies", "ProductionDate", c => c.DateTime(nullable: false, storeType: "date"));
            AddColumn("Operation.Supplies", "ExpireDuration", c => c.Int(nullable: false));
            AlterStoredProcedure(
                "Main.Demand_Insert",
                p => new
                    {
                        Code = p.Guid(),
                        ItemCode = p.Int(),
                        WarehouseName = p.String(maxLength: 20),
                        Time = p.DateTime(),
                        ProductionDate = p.DateTime(storeType: "date"),
                        ExpireDuration = p.Int(),
                        Quantity = p.Int(),
                        CustomerEmail = p.String(maxLength: 128),
                    },
                body:
                    @"INSERT [Operation].[Demands]([Code], [ItemCode], [WarehouseName], [Time], [ProductionDate], [ExpireDuration], [Quantity], [CustomerEmail])
                      VALUES (@Code, @ItemCode, @WarehouseName, @Time, @ProductionDate, @ExpireDuration, @Quantity, @CustomerEmail)"
            );
            
            AlterStoredProcedure(
                "Main.Demand_Update",
                p => new
                    {
                        Code = p.Guid(),
                        ItemCode = p.Int(),
                        WarehouseName = p.String(maxLength: 20),
                        Time = p.DateTime(),
                        ProductionDate = p.DateTime(storeType: "date"),
                        ExpireDuration = p.Int(),
                        Quantity = p.Int(),
                        CustomerEmail = p.String(maxLength: 128),
                    },
                body:
                    @"UPDATE [Operation].[Demands]
                      SET [ItemCode] = @ItemCode, [WarehouseName] = @WarehouseName, [Time] = @Time, [ProductionDate] = @ProductionDate, [ExpireDuration] = @ExpireDuration, [Quantity] = @Quantity, [CustomerEmail] = @CustomerEmail
                      WHERE ([Code] = @Code)"
            );
            
            AlterStoredProcedure(
                "Main.Supply_Insert",
                p => new
                    {
                        Code = p.Guid(),
                        ItemCode = p.Int(),
                        WarehouseName = p.String(maxLength: 20),
                        Time = p.DateTime(),
                        ProductionDate = p.DateTime(storeType: "date"),
                        ExpireDuration = p.Int(),
                        Quantity = p.Int(),
                        SupplierEmail = p.String(maxLength: 128),
                    },
                body:
                    @"INSERT [Operation].[Supplies]([Code], [ItemCode], [WarehouseName], [Time], [ProductionDate], [ExpireDuration], [Quantity], [SupplierEmail])
                      VALUES (@Code, @ItemCode, @WarehouseName, @Time, @ProductionDate, @ExpireDuration, @Quantity, @SupplierEmail)"
            );
            
            AlterStoredProcedure(
                "Main.Supply_Update",
                p => new
                    {
                        Code = p.Guid(),
                        ItemCode = p.Int(),
                        WarehouseName = p.String(maxLength: 20),
                        Time = p.DateTime(),
                        ProductionDate = p.DateTime(storeType: "date"),
                        ExpireDuration = p.Int(),
                        Quantity = p.Int(),
                        SupplierEmail = p.String(maxLength: 128),
                    },
                body:
                    @"UPDATE [Operation].[Supplies]
                      SET [ItemCode] = @ItemCode, [WarehouseName] = @WarehouseName, [Time] = @Time, [ProductionDate] = @ProductionDate, [ExpireDuration] = @ExpireDuration, [Quantity] = @Quantity, [SupplierEmail] = @SupplierEmail
                      WHERE ([Code] = @Code)"
            );
            
        }
        
        public override void Down()
        {
            DropColumn("Operation.Supplies", "ExpireDuration");
            DropColumn("Operation.Supplies", "ProductionDate");
            DropColumn("Operation.Demands", "ExpireDuration");
            DropColumn("Operation.Demands", "ProductionDate");
            throw new NotSupportedException("Scaffolding create or alter procedure operations is not supported in down methods.");
        }
    }
}
