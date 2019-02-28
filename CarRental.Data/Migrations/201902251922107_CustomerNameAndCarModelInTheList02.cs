namespace CarRental.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CustomerNameAndCarModelInTheList02 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.DataTransaction", "CustomerName", c => c.String());
            AddColumn("dbo.DataTransaction", "CarModel", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.DataTransaction", "CarModel");
            DropColumn("dbo.DataTransaction", "CustomerName");
        }
    }
}
