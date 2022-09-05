namespace E_Shop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ScriptsA4 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Products", "isAvailable", c => c.Boolean(nullable: false));
            DropColumn("dbo.Products", "Stock");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Products", "Stock", c => c.String(maxLength: 50));
            DropColumn("dbo.Products", "isAvailable");
        }
    }
}
