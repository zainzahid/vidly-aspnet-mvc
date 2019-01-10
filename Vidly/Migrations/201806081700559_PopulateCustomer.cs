namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateCustomer : DbMigration
    {
        public override void Up()
        {
            Sql("UPDATE Customers SET BirthDate='11/1/1998' WHERE Id=4 ;");
            Sql("UPDATE Customers SET BirthDate='18/5/1995' WHERE Id=6 ;");
        }
        
        public override void Down()
        {
        }
    }
}
