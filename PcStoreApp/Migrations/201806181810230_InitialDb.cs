namespace PcStoreApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialDb : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Quantity = c.Int(nullable: false),
                        PurchasePrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        SalePrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Recives",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Customer = c.String(),
                        Date = c.DateTime(nullable: false),
                        Total = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Quantity = c.Int(nullable: false),
                        ProductId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Products", t => t.ProductId, cascadeDelete: true)
                .Index(t => t.ProductId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Recives", "ProductId", "dbo.Products");
            DropIndex("dbo.Recives", new[] { "ProductId" });
            DropTable("dbo.Recives");
            DropTable("dbo.Products");
        }
    }
}
