namespace Stock_Management.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DatasizeIncreaseinTable : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Products", "Name", c => c.String(maxLength: 20));
            AlterColumn("dbo.Products", "Description", c => c.String(maxLength: 255));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Products", "Description", c => c.String());
            AlterColumn("dbo.Products", "Name", c => c.String());
        }
    }
}
