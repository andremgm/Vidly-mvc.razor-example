namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changesInCustomers : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.MembershipTypes", "membershipName", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.MembershipTypes", "membershipName", c => c.String());
        }
    }
}
