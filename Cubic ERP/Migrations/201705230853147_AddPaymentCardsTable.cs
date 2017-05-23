namespace Cubic_ERP.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddPaymentCardsTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PaymentCards",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Code = c.String(nullable: false, maxLength: 50),
                        Name = c.String(nullable: false, maxLength: 128),
                        CardTypeId = c.Int(nullable: false),
                        AuditUserId = c.Int(),
                        AuditTimeStamp = c.DateTimeOffset(precision: 7),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.CardTypes", t => t.CardTypeId, cascadeDelete: true)
                .Index(t => t.CardTypeId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PaymentCards", "CardTypeId", "dbo.CardTypes");
            DropIndex("dbo.PaymentCards", new[] { "CardTypeId" });
            DropTable("dbo.PaymentCards");
        }
    }
}
