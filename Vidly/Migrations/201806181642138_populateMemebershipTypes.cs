namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class populateMemebershipTypes : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.MembershipTypes", "membershipName", c => c.String());
            Sql("INSERT INTO MembershipTypes(Id,signUpFee,durationInMonths,discountRate,membershipName) VALUES (1, 0 , 0 , 0 ,'Pay as you go ') ");
            Sql("INSERT INTO MembershipTypes(Id,signUpFee,durationInMonths,discountRate,membershipName) VALUES (2, 30 , 1 , 10 ,'Monthly') ");
            Sql("INSERT INTO MembershipTypes(Id,signUpFee,durationInMonths,discountRate,membershipName) VALUES (3, 50 , 3 , 15 ,'Trimester') ");
            Sql("INSERT INTO MembershipTypes(Id,signUpFee,durationInMonths,discountRate,membershipName) VALUES (4,100 , 12 , 20 ,'Yearly ') ");

        }
        
        public override void Down()
        {
            DropColumn("dbo.MembershipTypes", "membershipName");
        }
    }
}
