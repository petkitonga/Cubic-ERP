namespace Cubic_ERP.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddTableCashFlowSetups : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CashFlowSetups",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CashFlowHeadingId = c.Int(nullable: false),
                        AccountMasterId = c.Int(nullable: false),
                        AuditUserId = c.Int(),
                        AuditTimeStamp = c.DateTimeOffset(precision: 7),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AccountMasters", t => t.AccountMasterId, cascadeDelete: true)
                .ForeignKey("dbo.CashFlowHeadings", t => t.CashFlowHeadingId, cascadeDelete: true)
                .Index(t => t.CashFlowHeadingId)
                .Index(t => t.AccountMasterId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CashFlowSetups", "CashFlowHeadingId", "dbo.CashFlowHeadings");
            DropForeignKey("dbo.CashFlowSetups", "AccountMasterId", "dbo.AccountMasters");
            DropIndex("dbo.CashFlowSetups", new[] { "AccountMasterId" });
            DropIndex("dbo.CashFlowSetups", new[] { "CashFlowHeadingId" });
            DropTable("dbo.CashFlowSetups");
        }
    }
}
