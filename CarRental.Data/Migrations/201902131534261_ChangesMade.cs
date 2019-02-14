namespace CarRental.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangesMade : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.CarRentalCar", newName: "DataCar");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.DataCar", newName: "CarRentalCar");
        }
    }
}
