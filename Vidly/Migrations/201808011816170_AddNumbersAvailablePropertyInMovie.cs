namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddNumbersAvailablePropertyInMovie : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Movies", "NumbersAvailable", c => c.Int(nullable: false));
            Sql("UPDATE Movies SET NumbersAvailable=NumbersInStock");
        }
        
        public override void Down()
        {
            DropColumn("dbo.Movies", "NumbersAvailable");
        }
    }
}
