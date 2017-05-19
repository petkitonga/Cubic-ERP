namespace Cubic_ERP.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCurrenciesTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Currencies",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CurrencyCode = c.String(nullable: false, maxLength: 50),
                        CurrencySymbol = c.String(maxLength: 50),
                        CurrencyName = c.String(nullable: false, maxLength: 50),
                        HundredthName = c.String(maxLength: 50),
                        AuditUserId = c.Int(),
                        AuditTimeStamp = c.DateTimeOffset(precision: 7),
                        Deleted = c.Boolean(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Currencies");
        }
    }
}
