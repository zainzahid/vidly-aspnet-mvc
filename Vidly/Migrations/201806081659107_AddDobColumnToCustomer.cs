namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddDobColumnToCustomer : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customers", "BirthDate", c => c.String());
            DropColumn("dbo.MembershipTypes", "BirthDate");
        }
        
        public override void Down()
        {
            AddColumn("dbo.MembershipTypes", "BirthDate", c => c.String());
            DropColumn("dbo.Customers", "BirthDate");
        }
    }
}
