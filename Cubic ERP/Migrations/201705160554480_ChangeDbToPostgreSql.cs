namespace Cubic_ERP.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeDbToPostgreSql : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.AspNetUsers", "LockoutEndDateUtc", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.AspNetUsers", "LockoutEndDateUtc", c => c.DateTime());
        }
    }
}
