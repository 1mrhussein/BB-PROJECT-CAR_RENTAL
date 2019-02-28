namespace CarRental.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CustomerNameAndCarModelInTheList01 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.DataTransaction", "CustomerName");
            DropColumn("dbo.DataTransaction", "CarModel");
        }
        
        public override void Down()
        {
            AddColumn("dbo.DataTransaction", "CarModel", c => c.String());
            AddColumn("dbo.DataTransaction", "CustomerName", c => c.String());
        }
    }
}
