namespace CarRental.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mii : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.DataTransaction", "PickUpDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.DataTransaction", "RetunrDate", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.DataTransaction", "RetunrDate", c => c.DateTimeOffset(nullable: false, precision: 7));
            AlterColumn("dbo.DataTransaction", "PickUpDate", c => c.DateTimeOffset(nullable: false, precision: 7));
        }
    }
}
