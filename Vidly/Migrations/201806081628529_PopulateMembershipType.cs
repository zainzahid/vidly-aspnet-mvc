namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateMembershipType : DbMigration
    {
        public override void Up()
        {
            Sql("UPDATE MemberShipTypes SET MembershipTypeName = 'Pay As You Go' WHERE Id = 1; ");
            Sql("UPDATE MemberShipTypes SET MembershipTypeName = 'Monthly' WHERE Id = 2; ");
        }
        
        public override void Down()
        {
        }
    }
}
