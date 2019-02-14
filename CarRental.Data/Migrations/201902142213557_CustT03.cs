namespace CarRental.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CustT03 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.DataCar", "CarIsAvailable");
        }
        
        public override void Down()
        {
            AddColumn("dbo.DataCar", "CarIsAvailable", c => c.Boolean(nullable: false));
        }
    }
}
