namespace Cubic_ERP.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCostCentersTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CostCenters",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 128),
                        Code = c.String(nullable: false, maxLength: 50),
                        AuditUserId = c.Int(),
                        AuditTimeStamp = c.DateTimeOffset(precision: 7),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.CostCenters");
        }
    }
}
