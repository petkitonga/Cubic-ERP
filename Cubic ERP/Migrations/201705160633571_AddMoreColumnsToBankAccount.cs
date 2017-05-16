namespace Cubic_ERP.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddMoreColumnsToBankAccount : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.BankAccounts", "AccountId", c => c.Int());
            AddColumn("dbo.BankAccounts", "MaintainedByUserId", c => c.Int());
            AddColumn("dbo.BankAccounts", "IsMerchantAccount", c => c.Boolean(nullable: false));
            AddColumn("dbo.BankAccounts", "OfficeId", c => c.Int());
            AddColumn("dbo.BankAccounts", "BankName", c => c.String(maxLength: 128));
            AddColumn("dbo.BankAccounts", "BankBranch", c => c.String(maxLength: 128));
            AddColumn("dbo.BankAccounts", "BankContactNumber", c => c.String(maxLength: 128));
            AddColumn("dbo.BankAccounts", "BankAccountNumber", c => c.String(maxLength: 128));
            AddColumn("dbo.BankAccounts", "BankAccountType", c => c.String(maxLength: 128));
            AddColumn("dbo.BankAccounts", "Street", c => c.String(maxLength: 50));
            AddColumn("dbo.BankAccounts", "City", c => c.String(maxLength: 50));
            AddColumn("dbo.BankAccounts", "State", c => c.String(maxLength: 50));
            AddColumn("dbo.BankAccounts", "Country", c => c.String(maxLength: 50));
            AddColumn("dbo.BankAccounts", "Phone", c => c.String(maxLength: 50));
            AddColumn("dbo.BankAccounts", "Fax", c => c.String(maxLength: 50));
            AddColumn("dbo.BankAccounts", "Cell", c => c.String(maxLength: 50));
            AddColumn("dbo.BankAccounts", "RelationshipOfficerName", c => c.String());
            AddColumn("dbo.BankAccounts", "RelationshipOfficerContactNumber", c => c.String());
            AddColumn("dbo.BankAccounts", "AuditUserId", c => c.Int());
            AddColumn("dbo.BankAccounts", "AuditTimeStamp", c => c.DateTimeOffset(precision: 7));
            AddColumn("dbo.BankAccounts", "Deleted", c => c.Boolean());
        }
        
        public override void Down()
        {
            DropColumn("dbo.BankAccounts", "Deleted");
            DropColumn("dbo.BankAccounts", "AuditTimeStamp");
            DropColumn("dbo.BankAccounts", "AuditUserId");
            DropColumn("dbo.BankAccounts", "RelationshipOfficerContactNumber");
            DropColumn("dbo.BankAccounts", "RelationshipOfficerName");
            DropColumn("dbo.BankAccounts", "Cell");
            DropColumn("dbo.BankAccounts", "Fax");
            DropColumn("dbo.BankAccounts", "Phone");
            DropColumn("dbo.BankAccounts", "Country");
            DropColumn("dbo.BankAccounts", "State");
            DropColumn("dbo.BankAccounts", "City");
            DropColumn("dbo.BankAccounts", "Street");
            DropColumn("dbo.BankAccounts", "BankAccountType");
            DropColumn("dbo.BankAccounts", "BankAccountNumber");
            DropColumn("dbo.BankAccounts", "BankContactNumber");
            DropColumn("dbo.BankAccounts", "BankBranch");
            DropColumn("dbo.BankAccounts", "BankName");
            DropColumn("dbo.BankAccounts", "OfficeId");
            DropColumn("dbo.BankAccounts", "IsMerchantAccount");
            DropColumn("dbo.BankAccounts", "MaintainedByUserId");
            DropColumn("dbo.BankAccounts", "AccountId");
        }
    }
}
