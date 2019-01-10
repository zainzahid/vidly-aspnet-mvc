namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddDobColumn : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.MembershipTypes", "BirthDate", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.MembershipTypes", "BirthDate");
        }
    }
}
