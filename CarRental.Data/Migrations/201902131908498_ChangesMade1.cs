namespace CarRental.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangesMade1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.DataCar", "CarMake", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.DataCar", "CarMake");
        }
    }
}
