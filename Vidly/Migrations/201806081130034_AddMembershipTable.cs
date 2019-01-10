namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddMembershipTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.MembershipTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SignUpFee = c.Short(nullable: false),
                        DurationInMonth = c.Byte(nullable: false),
                        DiscountRate = c.Byte(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Customers", "MembershipType_Id", c => c.Int());
            AlterColumn("dbo.Customers", "MembershipId", c => c.Int(nullable: false));
            CreateIndex("dbo.Customers", "MembershipType_Id");
            AddForeignKey("dbo.Customers", "MembershipType_Id", "dbo.MembershipTypes", "Id");
            DropColumn("dbo.Customers", "MembershipType_MembershipId");
            DropColumn("dbo.Customers", "MembershipType_SignUpFee");
            DropColumn("dbo.Customers", "MembershipType_DurationInMonth");
            DropColumn("dbo.Customers", "MembershipType_DiscountRate");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Customers", "MembershipType_DiscountRate", c => c.Byte(nullable: false));
            AddColumn("dbo.Customers", "MembershipType_DurationInMonth", c => c.Byte(nullable: false));
            AddColumn("dbo.Customers", "MembershipType_SignUpFee", c => c.Short(nullable: false));
            AddColumn("dbo.Customers", "MembershipType_MembershipId", c => c.Byte(nullable: false));
            DropForeignKey("dbo.Customers", "MembershipType_Id", "dbo.MembershipTypes");
            DropIndex("dbo.Customers", new[] { "MembershipType_Id" });
            AlterColumn("dbo.Customers", "MembershipId", c => c.Byte(nullable: false));
            DropColumn("dbo.Customers", "MembershipType_Id");
            DropTable("dbo.MembershipTypes");
        }
    }
}
