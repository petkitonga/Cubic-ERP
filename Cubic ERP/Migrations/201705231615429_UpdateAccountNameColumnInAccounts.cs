namespace Cubic_ERP.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateAccountNameColumnInAccounts : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Accounts", "AccountName", c => c.String(nullable: false, maxLength: 255));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Accounts", "AccountName", c => c.String(maxLength: 255));
        }
    }
}
