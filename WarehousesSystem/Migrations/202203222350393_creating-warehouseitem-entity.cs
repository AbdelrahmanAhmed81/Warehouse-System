namespace WarehouseSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class creatingwarehouseitementity : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "Main.WarehouseItems",
                c => new
                    {
                        WarehouseName = c.String(nullable: false, maxLength: 20),
                        ItemCode = c.Int(nullable: false),
                        Quantity = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.WarehouseName, t.ItemCode })
                .ForeignKey("Main.Items", t => t.ItemCode, cascadeDelete: true)
                .ForeignKey("Main.Warehouses", t => t.WarehouseName, cascadeDelete: true)
                .Index(t => t.WarehouseName)
                .Index(t => t.ItemCode);
            
            CreateStoredProcedure(
                "Main.WarehouseItem_Insert",
                p => new
                    {
                        WarehouseName = p.String(maxLength: 20),
                        ItemCode = p.Int(),
                        Quantity = p.Int(),
                    },
                body:
                    @"INSERT [Main].[WarehouseItems]([WarehouseName], [ItemCode], [Quantity])
                      VALUES (@WarehouseName, @ItemCode, @Quantity)"
            );
            
            CreateStoredProcedure(
                "Main.WarehouseItem_Update",
                p => new
                    {
                        WarehouseName = p.String(maxLength: 20),
                        ItemCode = p.Int(),
                        Quantity = p.Int(),
                    },
                body:
                    @"UPDATE [Main].[WarehouseItems]
                      SET [Quantity] = @Quantity
                      WHERE (([WarehouseName] = @WarehouseName) AND ([ItemCode] = @ItemCode))"
            );
            
            CreateStoredProcedure(
                "Main.WarehouseItem_Delete",
                p => new
                    {
                        WarehouseName = p.String(maxLength: 20),
                        ItemCode = p.Int(),
                    },
                body:
                    @"DELETE [Main].[WarehouseItems]
                      WHERE (([WarehouseName] = @WarehouseName) AND ([ItemCode] = @ItemCode))"
            );
            
        }
        
        public override void Down()
        {
            DropStoredProcedure("Main.WarehouseItem_Delete");
            DropStoredProcedure("Main.WarehouseItem_Update");
            DropStoredProcedure("Main.WarehouseItem_Insert");
            DropForeignKey("Main.WarehouseItems", "WarehouseName", "Main.Warehouses");
            DropForeignKey("Main.WarehouseItems", "ItemCode", "Main.Items");
            DropIndex("Main.WarehouseItems", new[] { "ItemCode" });
            DropIndex("Main.WarehouseItems", new[] { "WarehouseName" });
            DropTable("Main.WarehouseItems");
        }
    }
}
