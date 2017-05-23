namespace Cubic_ERP.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddAccountMasterToAccountRelationship : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.Accounts", "AccountMasterId");
            AddForeignKey("dbo.Accounts", "AccountMasterId", "dbo.AccountMasters", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Accounts", "AccountMasterId", "dbo.AccountMasters");
            DropIndex("dbo.Accounts", new[] { "AccountMasterId" });
        }
    }
}
