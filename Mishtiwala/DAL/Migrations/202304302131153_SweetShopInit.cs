namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SweetShopInit : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Areas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 255),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 255),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.DeliveryHistories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Offers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IsActive = c.Boolean(nullable: false),
                        DiscountAmount = c.Double(nullable: false),
                        SweetId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Sweets", t => t.SweetId, cascadeDelete: true)
                .Index(t => t.SweetId);
            
            CreateTable(
                "dbo.Sweets",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 255),
                        Description = c.String(nullable: false),
                        Price = c.Double(nullable: false),
                        CategoryId = c.Int(nullable: false),
                        AreaId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Areas", t => t.AreaId, cascadeDelete: true)
                .ForeignKey("dbo.Categories", t => t.CategoryId, cascadeDelete: true)
                .Index(t => t.CategoryId)
                .Index(t => t.AreaId);
            
            CreateTable(
                "dbo.Payments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.TransactionHistories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Offers", "SweetId", "dbo.Sweets");
            DropForeignKey("dbo.Sweets", "CategoryId", "dbo.Categories");
            DropForeignKey("dbo.Sweets", "AreaId", "dbo.Areas");
            DropIndex("dbo.Sweets", new[] { "AreaId" });
            DropIndex("dbo.Sweets", new[] { "CategoryId" });
            DropIndex("dbo.Offers", new[] { "SweetId" });
            DropTable("dbo.TransactionHistories");
            DropTable("dbo.Payments");
            DropTable("dbo.Sweets");
            DropTable("dbo.Offers");
            DropTable("dbo.DeliveryHistories");
            DropTable("dbo.Categories");
            DropTable("dbo.Areas");
        }
    }
}
