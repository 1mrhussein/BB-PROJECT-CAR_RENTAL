namespace CarRental.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangesMade09 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.DataCar", "CarMake");
        }
        
        public override void Down()
        {
            AddColumn("dbo.DataCar", "CarMake", c => c.String(nullable: false));
        }
    }
}
