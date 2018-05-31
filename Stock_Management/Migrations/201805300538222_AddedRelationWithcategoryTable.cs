namespace Stock_Management.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedRelationWithcategoryTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Category",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Categoryname = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Products", "category_Id", c => c.Int());
            CreateIndex("dbo.Products", "category_Id");
            AddForeignKey("dbo.Products", "category_Id", "dbo.Category", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Products", "category_Id", "dbo.Category");
            DropIndex("dbo.Products", new[] { "category_Id" });
            DropColumn("dbo.Products", "category_Id");
            DropTable("dbo.Category");
        }
    }
}
