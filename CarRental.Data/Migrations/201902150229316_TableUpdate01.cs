namespace CarRental.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TableUpdate01 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.DataCar", "CarIsAvailable", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.DataCar", "CarIsAvailable");
        }
    }
}
