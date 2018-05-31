namespace Stock_Management.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DataTypeChangedSaleTable : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Sales", "Price", c => c.Single(nullable: false));
            AlterColumn("dbo.Sales", "Total", c => c.Single(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Sales", "Total", c => c.Int(nullable: false));
            AlterColumn("dbo.Sales", "Price", c => c.Int(nullable: false));
        }
    }
}
