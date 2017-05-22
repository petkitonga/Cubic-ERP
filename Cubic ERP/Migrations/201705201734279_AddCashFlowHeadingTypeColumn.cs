namespace Cubic_ERP.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCashFlowHeadingTypeColumn : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CashFlowHeadings", "CashFlowHeadingType", c => c.String(nullable: false, maxLength: 1));
        }
        
        public override void Down()
        {
            DropColumn("dbo.CashFlowHeadings", "CashFlowHeadingType");
        }
    }
}
