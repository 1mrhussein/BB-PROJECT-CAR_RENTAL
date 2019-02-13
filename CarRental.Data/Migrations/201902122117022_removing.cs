namespace CarRental.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class removing : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.CarRentalCar", "CarMake");
        }
        
        public override void Down()
        {
            AddColumn("dbo.CarRentalCar", "CarMake", c => c.String(nullable: false));
        }
    }
}
