namespace Cubic_ERP.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddingAccountsTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Accounts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        AccountMasterId = c.Int(),
                        AccountNumber = c.String(maxLength: 50),
                        ExternalCode = c.String(maxLength: 50),
                        CurrencyCode = c.String(maxLength: 50),
                        AccountName = c.String(maxLength: 255),
                        Description = c.String(maxLength: 1000),
                        Confidential = c.Boolean(),
                        IsTransactionNode = c.Boolean(),
                        SysType = c.Boolean(),
                        ParentAccountId = c.Int(nullable: false),
                        AuditUserId = c.Int(),
                        AuditTimeStamp = c.DateTimeOffset(precision: 7),
                        Deleted = c.Boolean(),
                    })
                .PrimaryKey(t => t.Id);
            
            AlterColumn("dbo.BankAccounts", "AccountId", c => c.Int(nullable: false));
            AlterColumn("dbo.BankAccounts", "RelationshipOfficerName", c => c.String(maxLength: 128));
            AlterColumn("dbo.BankAccounts", "RelationshipOfficerContactNumber", c => c.String(maxLength: 128));
            CreateIndex("dbo.BankAccounts", "AccountId");
            AddForeignKey("dbo.BankAccounts", "AccountId", "dbo.Accounts", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.BankAccounts", "AccountId", "dbo.Accounts");
            DropIndex("dbo.BankAccounts", new[] { "AccountId" });
            AlterColumn("dbo.BankAccounts", "RelationshipOfficerContactNumber", c => c.String());
            AlterColumn("dbo.BankAccounts", "RelationshipOfficerName", c => c.String());
            AlterColumn("dbo.BankAccounts", "AccountId", c => c.Int());
            DropTable("dbo.Accounts");
        }
    }
}
