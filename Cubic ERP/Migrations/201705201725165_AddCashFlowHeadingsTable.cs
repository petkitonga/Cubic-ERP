namespace Cubic_ERP.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCashFlowHeadingsTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CashFlowHeadings",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CashFlowHeadingCode = c.String(nullable: false, maxLength: 20),
                        CashFlowHeadingName = c.String(nullable: false, maxLength: 255),
                        IsDebit = c.Boolean(nullable: false),
                        IsSales = c.Boolean(nullable: false),
                        IsPurchase = c.Boolean(nullable: false),
                        AuditUserId = c.Int(),
                        AuditTimeStamp = c.DateTimeOffset(precision: 7),
                        Deleted = c.Boolean(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.CashFlowHeadings");
        }
    }
}
