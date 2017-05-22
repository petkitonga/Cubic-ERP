namespace Cubic_ERP.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddAgeingSlabsTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AgeingSlabs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        FromDays = c.Int(nullable: false),
                        ToDays = c.Int(nullable: false),
                        AuditUserId = c.Int(),
                        AuditTimeStamp = c.DateTimeOffset(precision: 7),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.AgeingSlabs");
        }
    }
}
