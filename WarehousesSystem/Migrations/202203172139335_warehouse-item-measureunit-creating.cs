namespace WarehouseSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class warehouseitemmeasureunitcreating : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "Main.ItemMeasureUnits",
                c => new
                    {
                        ItemCode = c.Int(nullable: false),
                        MeasureUnit = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.ItemCode, t.MeasureUnit })
                .ForeignKey("Main.Items", t => t.ItemCode, cascadeDelete: true)
                .Index(t => t.ItemCode);
            
            CreateTable(
                "Main.Items",
                c => new
                    {
                        ItemCode = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 25),
                    })
                .PrimaryKey(t => t.ItemCode);
            
            CreateTable(
                "Main.Warehouses",
                c => new
                    {
                        WarehouseName = c.String(nullable: false, maxLength: 20),
                        Address = c.String(nullable: false, maxLength: 50),
                        ManagerName = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.WarehouseName);
            
            CreateStoredProcedure(
                "Main.ItemMeasureUnit_Insert",
                p => new
                    {
                        ItemCode = p.Int(),
                        MeasureUnit = p.Int(),
                    },
                body:
                    @"INSERT [Main].[ItemMeasureUnits]([ItemCode], [MeasureUnit])
                      VALUES (@ItemCode, @MeasureUnit)"
            );
            
            CreateStoredProcedure(
                "Main.ItemMeasureUnit_Update",
                p => new
                    {
                        ItemCode = p.Int(),
                        MeasureUnit = p.Int(),
                    },
                body:
                    @"RETURN"
            );
            
            CreateStoredProcedure(
                "Main.ItemMeasureUnit_Delete",
                p => new
                    {
                        ItemCode = p.Int(),
                        MeasureUnit = p.Int(),
                    },
                body:
                    @"DELETE [Main].[ItemMeasureUnits]
                      WHERE (([ItemCode] = @ItemCode) AND ([MeasureUnit] = @MeasureUnit))"
            );
            
            CreateStoredProcedure(
                "Main.Item_Insert",
                p => new
                    {
                        Name = p.String(maxLength: 25),
                    },
                body:
                    @"INSERT [Main].[Items]([Name])
                      VALUES (@Name)
                      
                      DECLARE @ItemCode int
                      SELECT @ItemCode = [ItemCode]
                      FROM [Main].[Items]
                      WHERE @@ROWCOUNT > 0 AND [ItemCode] = scope_identity()
                      
                      SELECT t0.[ItemCode]
                      FROM [Main].[Items] AS t0
                      WHERE @@ROWCOUNT > 0 AND t0.[ItemCode] = @ItemCode"
            );
            
            CreateStoredProcedure(
                "Main.Item_Update",
                p => new
                    {
                        ItemCode = p.Int(),
                        Name = p.String(maxLength: 25),
                    },
                body:
                    @"UPDATE [Main].[Items]
                      SET [Name] = @Name
                      WHERE ([ItemCode] = @ItemCode)"
            );
            
            CreateStoredProcedure(
                "Main.Item_Delete",
                p => new
                    {
                        ItemCode = p.Int(),
                    },
                body:
                    @"DELETE [Main].[Items]
                      WHERE ([ItemCode] = @ItemCode)"
            );
            
            CreateStoredProcedure(
                "Main.Warehouse_Insert",
                p => new
                    {
                        WarehouseName = p.String(maxLength: 20),
                        Address = p.String(maxLength: 50),
                        ManagerName = p.String(maxLength: 50),
                    },
                body:
                    @"INSERT [Main].[Warehouses]([WarehouseName], [Address], [ManagerName])
                      VALUES (@WarehouseName, @Address, @ManagerName)"
            );
            
            CreateStoredProcedure(
                "Main.Warehouse_Update",
                p => new
                    {
                        WarehouseName = p.String(maxLength: 20),
                        Address = p.String(maxLength: 50),
                        ManagerName = p.String(maxLength: 50),
                    },
                body:
                    @"UPDATE [Main].[Warehouses]
                      SET [Address] = @Address, [ManagerName] = @ManagerName
                      WHERE ([WarehouseName] = @WarehouseName)"
            );
            
            CreateStoredProcedure(
                "Main.Warehouse_Delete",
                p => new
                    {
                        WarehouseName = p.String(maxLength: 20),
                    },
                body:
                    @"DELETE [Main].[Warehouses]
                      WHERE ([WarehouseName] = @WarehouseName)"
            );
            
        }
        
        public override void Down()
        {
            DropStoredProcedure("Main.Warehouse_Delete");
            DropStoredProcedure("Main.Warehouse_Update");
            DropStoredProcedure("Main.Warehouse_Insert");
            DropStoredProcedure("Main.Item_Delete");
            DropStoredProcedure("Main.Item_Update");
            DropStoredProcedure("Main.Item_Insert");
            DropStoredProcedure("Main.ItemMeasureUnit_Delete");
            DropStoredProcedure("Main.ItemMeasureUnit_Update");
            DropStoredProcedure("Main.ItemMeasureUnit_Insert");
            DropForeignKey("Main.ItemMeasureUnits", "ItemCode", "Main.Items");
            DropIndex("Main.ItemMeasureUnits", new[] { "ItemCode" });
            DropTable("Main.Warehouses");
            DropTable("Main.Items");
            DropTable("Main.ItemMeasureUnits");
        }
    }
}
