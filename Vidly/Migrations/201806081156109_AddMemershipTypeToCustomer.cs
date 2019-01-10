namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddMemershipTypeToCustomer : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customers", "MembershipTypeId", c => c.Int(nullable: false));
            CreateIndex("dbo.Customers", "MembershipTypeId");
            AddForeignKey("dbo.Customers", "MembershipTypeId", "dbo.MembershipTypes", "Id", cascadeDelete: true);
            DropColumn("dbo.Customers", "MembershipId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Customers", "MembershipId", c => c.Int(nullable: false));
            DropForeignKey("dbo.Customers", "MembershipTypeId", "dbo.MembershipTypes");
            DropIndex("dbo.Customers", new[] { "MembershipTypeId" });
            DropColumn("dbo.Customers", "MembershipTypeId");
        }
    }
}
