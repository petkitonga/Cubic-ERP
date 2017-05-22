namespace Cubic_ERP.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddAccountMastersTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AccountMasters",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Code = c.String(nullable: false, maxLength: 50),
                        Name = c.String(nullable: false, maxLength: 50),
                        NormallyDebit = c.Boolean(nullable: false),
                        ParentAccountMaster = c.Int(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.AccountMasters");
        }
    }
}
