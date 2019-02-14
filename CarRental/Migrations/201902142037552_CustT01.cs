namespace CarRental.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CustT01 : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.CarRentalCars", newName: "DataCars");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.DataCars", newName: "CarRentalCars");
        }
    }
}
