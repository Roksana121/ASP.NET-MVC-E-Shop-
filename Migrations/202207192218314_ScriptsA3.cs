namespace E_Shop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ScriptsA3 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Products", "Stock", c => c.String(maxLength: 50));
            DropColumn("dbo.Products", "StockIn");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Products", "StockIn", c => c.String(maxLength: 50));
            DropColumn("dbo.Products", "Stock");
        }
    }
}
