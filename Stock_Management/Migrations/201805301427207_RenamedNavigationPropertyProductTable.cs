namespace Stock_Management.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RenamedNavigationPropertyProductTable : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Products", new[] { "category_Id" });
            CreateIndex("dbo.Products", "Category_Id");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Products", new[] { "Category_Id" });
            CreateIndex("dbo.Products", "category_Id");
        }
    }
}
