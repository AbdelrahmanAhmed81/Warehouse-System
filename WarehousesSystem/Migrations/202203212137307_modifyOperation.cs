namespace WarehouseSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class modifyOperation : DbMigration
    {
        public override void Up()
        {
            AddColumn("Operation.Supplies", "ExpireDays", c => c.Int(nullable: false));
            DropColumn("Operation.Demands", "ProductionDate");
            DropColumn("Operation.Demands", "ExpireDuration");
            DropColumn("Operation.Supplies", "ExpireDuration");
            AlterStoredProcedure(
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
            
            AlterStoredProcedure(
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
            
            AlterStoredProcedure(
                "Main.Supply_Insert",
                p => new
                    {
                        Code = p.Guid(),
                        ItemCode = p.Int(),
                        WarehouseName = p.String(maxLength: 20),
                        Time = p.DateTime(),
                        Quantity = p.Int(),
                        SupplierEmail = p.String(maxLength: 128),
                        ProductionDate = p.DateTime(storeType: "date"),
                        ExpireDays = p.Int(),
                    },
                body:
                    @"INSERT [Operation].[Supplies]([Code], [ItemCode], [WarehouseName], [Time], [Quantity], [SupplierEmail], [ProductionDate], [ExpireDays])
                      VALUES (@Code, @ItemCode, @WarehouseName, @Time, @Quantity, @SupplierEmail, @ProductionDate, @ExpireDays)"
            );
            
            AlterStoredProcedure(
                "Main.Supply_Update",
                p => new
                    {
                        Code = p.Guid(),
                        ItemCode = p.Int(),
                        WarehouseName = p.String(maxLength: 20),
                        Time = p.DateTime(),
                        Quantity = p.Int(),
                        SupplierEmail = p.String(maxLength: 128),
                        ProductionDate = p.DateTime(storeType: "date"),
                        ExpireDays = p.Int(),
                    },
                body:
                    @"UPDATE [Operation].[Supplies]
                      SET [ItemCode] = @ItemCode, [WarehouseName] = @WarehouseName, [Time] = @Time, [Quantity] = @Quantity, [SupplierEmail] = @SupplierEmail, [ProductionDate] = @ProductionDate, [ExpireDays] = @ExpireDays
                      WHERE ([Code] = @Code)"
            );
            
        }
        
        public override void Down()
        {
            AddColumn("Operation.Supplies", "ExpireDuration", c => c.Int(nullable: false));
            AddColumn("Operation.Demands", "ExpireDuration", c => c.Int(nullable: false));
            AddColumn("Operation.Demands", "ProductionDate", c => c.DateTime(nullable: false, storeType: "date"));
            DropColumn("Operation.Supplies", "ExpireDays");
            throw new NotSupportedException("Scaffolding create or alter procedure operations is not supported in down methods.");
        }
    }
}
