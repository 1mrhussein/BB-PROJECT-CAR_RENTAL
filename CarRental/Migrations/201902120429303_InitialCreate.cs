namespace CarRental.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CarRentalCars",
                c => new
                    {
                        CarID = c.Int(nullable: false, identity: true),
                        CarMake = c.String(nullable: false),
                        CarModel = c.String(nullable: false),
                        CarSize = c.Int(nullable: false),
                        CarIsAvailable = c.Boolean(nullable: false),
                        CarYear = c.Int(nullable: false),
                        CarPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.CarID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.CarRentalCars");
        }
    }
}
