namespace Stock_Management.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedProfitAndLossTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ProfitAndLoss",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Date = c.DateTime(nullable: false),
                        ProductName = c.String(),
                        ProductValue = c.Single(nullable: false),
                        SoldValue = c.Single(nullable: false),
                        Profit = c.Single(nullable: false),
                        NetProfit = c.Single(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.ProfitAndLoss");
        }
    }
}
