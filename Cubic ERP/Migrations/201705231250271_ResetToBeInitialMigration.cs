namespace Cubic_ERP.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ResetToBeInitialMigration : DbMigration
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
            
            CreateTable(
                "dbo.Accounts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        AccountMasterId = c.Int(nullable: false),
                        AccountNumber = c.String(nullable: false, maxLength: 50),
                        ExternalCode = c.String(maxLength: 50),
                        CurrencyCode = c.String(nullable: false, maxLength: 50),
                        AccountName = c.String(maxLength: 255),
                        Description = c.String(maxLength: 1000),
                        Confidential = c.Boolean(nullable: false),
                        IsTransactionNode = c.Boolean(nullable: false),
                        SysType = c.Boolean(nullable: false),
                        ParentAccountId = c.Int(),
                        AuditUserId = c.Int(),
                        AuditTimeStamp = c.DateTimeOffset(precision: 7),
                        Deleted = c.Boolean(),
                    })
                .PrimaryKey(t => t.Id);
            
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
            
            CreateTable(
                "dbo.BankAccounts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 255),
                        AccountId = c.Int(nullable: false),
                        MaintainedByUserId = c.Int(),
                        IsMerchantAccount = c.Boolean(nullable: false),
                        OfficeId = c.Int(),
                        BankName = c.String(maxLength: 128),
                        BankBranch = c.String(maxLength: 128),
                        BankContactNumber = c.String(maxLength: 128),
                        BankAccountNumber = c.String(maxLength: 128),
                        BankAccountType = c.String(maxLength: 128),
                        Street = c.String(maxLength: 50),
                        City = c.String(maxLength: 50),
                        State = c.String(maxLength: 50),
                        Country = c.String(maxLength: 50),
                        Phone = c.String(maxLength: 50),
                        Fax = c.String(maxLength: 50),
                        Cell = c.String(maxLength: 50),
                        RelationshipOfficerName = c.String(maxLength: 128),
                        RelationshipOfficerContactNumber = c.String(maxLength: 128),
                        AuditUserId = c.Int(),
                        AuditTimeStamp = c.DateTimeOffset(precision: 7),
                        Deleted = c.Boolean(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Accounts", t => t.AccountId, cascadeDelete: true)
                .Index(t => t.AccountId);
            
            CreateTable(
                "dbo.CardTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Code = c.String(nullable: false, maxLength: 50),
                        Name = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.CashFlowHeadings",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CashFlowHeadingCode = c.String(nullable: false, maxLength: 20),
                        CashFlowHeadingName = c.String(nullable: false, maxLength: 255),
                        CashFlowHeadingType = c.String(nullable: false, maxLength: 1),
                        IsDebit = c.Boolean(nullable: false),
                        IsSales = c.Boolean(nullable: false),
                        IsPurchase = c.Boolean(nullable: false),
                        AuditUserId = c.Int(),
                        AuditTimeStamp = c.DateTimeOffset(precision: 7),
                        Deleted = c.Boolean(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.CashFlowSetups",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CashFlowHeadingId = c.Int(nullable: false),
                        AccountMasterId = c.Int(nullable: false),
                        AuditUserId = c.Int(),
                        AuditTimeStamp = c.DateTimeOffset(precision: 7),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AccountMasters", t => t.AccountMasterId, cascadeDelete: true)
                .ForeignKey("dbo.CashFlowHeadings", t => t.CashFlowHeadingId, cascadeDelete: true)
                .Index(t => t.CashFlowHeadingId)
                .Index(t => t.AccountMasterId);
            
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
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.PaymentCards", "CardTypeId", "dbo.CardTypes");
            DropForeignKey("dbo.CashFlowSetups", "CashFlowHeadingId", "dbo.CashFlowHeadings");
            DropForeignKey("dbo.CashFlowSetups", "AccountMasterId", "dbo.AccountMasters");
            DropForeignKey("dbo.BankAccounts", "AccountId", "dbo.Accounts");
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.PaymentCards", new[] { "CardTypeId" });
            DropIndex("dbo.CashFlowSetups", new[] { "AccountMasterId" });
            DropIndex("dbo.CashFlowSetups", new[] { "CashFlowHeadingId" });
            DropIndex("dbo.BankAccounts", new[] { "AccountId" });
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.PaymentCards");
            DropTable("dbo.Currencies");
            DropTable("dbo.CostCenters");
            DropTable("dbo.CashFlowSetups");
            DropTable("dbo.CashFlowHeadings");
            DropTable("dbo.CardTypes");
            DropTable("dbo.BankAccounts");
            DropTable("dbo.AgeingSlabs");
            DropTable("dbo.Accounts");
            DropTable("dbo.AccountMasters");
        }
    }
}
