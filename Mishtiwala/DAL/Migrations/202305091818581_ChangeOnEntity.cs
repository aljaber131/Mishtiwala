namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeOnEntity : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Payments", "Amount", c => c.Double(nullable: false));
            AddColumn("dbo.Payments", "SweetId", c => c.Int(nullable: false));
            AddColumn("dbo.Payments", "UserId", c => c.Int(nullable: false));
            CreateIndex("dbo.Payments", "SweetId");
            CreateIndex("dbo.Payments", "UserId");
            AddForeignKey("dbo.Payments", "SweetId", "dbo.Sweets", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Payments", "UserId", "dbo.Users", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Payments", "UserId", "dbo.Users");
            DropForeignKey("dbo.Payments", "SweetId", "dbo.Sweets");
            DropIndex("dbo.Payments", new[] { "UserId" });
            DropIndex("dbo.Payments", new[] { "SweetId" });
            DropColumn("dbo.Payments", "UserId");
            DropColumn("dbo.Payments", "SweetId");
            DropColumn("dbo.Payments", "Amount");
        }
    }
}
