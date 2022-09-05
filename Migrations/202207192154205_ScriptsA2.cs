namespace E_Shop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ScriptsA2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Products", "StockIn", c => c.String(maxLength: 50));
            DropColumn("dbo.Products", "Stock");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Products", "Stock", c => c.String(maxLength: 50));
            DropColumn("dbo.Products", "StockIn");
        }
    }
}
