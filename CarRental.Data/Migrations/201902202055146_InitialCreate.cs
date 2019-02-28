namespace CarRental.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.DataCar",
                c => new
                    {
                        CarID = c.Int(nullable: false, identity: true),
                        CarMake = c.String(nullable: false),
                        CarModel = c.String(nullable: false),
                        CarSize = c.Int(nullable: false),
                        CarYear = c.Int(nullable: false),
                        CarPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        CarIsAvailable = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.CarID);
            
            CreateTable(
                "dbo.DataCustomer",
                c => new
                    {
                        CustomerID = c.Int(nullable: false, identity: true),
                        CustomerName = c.String(nullable: false),
                        CustomerPhone = c.Int(nullable: false),
                        CustomerAddress = c.String(nullable: false),
                        CustomerLiscenceNo = c.Int(nullable: false),
                        CustomerDOB = c.DateTime(nullable: false),
                        CustomerRegistredDate = c.DateTimeOffset(nullable: false, precision: 7),
                    })
                .PrimaryKey(t => t.CustomerID);
            
            CreateTable(
                "dbo.DataTransaction",
                c => new
                    {
                        TransID = c.Int(nullable: false, identity: true),
                        TransDate = c.DateTimeOffset(nullable: false, precision: 7),
                        PickUpDate = c.DateTime(nullable: false),
                        RetunrDate = c.DateTime(nullable: false),
                        RentalAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        CarIsAvailable = c.Boolean(nullable: false),
                        CustomerIsRegistred = c.Boolean(nullable: false),
                        CarID = c.Int(nullable: false),
                        CustomerID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.TransID)
                .ForeignKey("dbo.DataCar", t => t.CarID, cascadeDelete: true)
                .ForeignKey("dbo.DataCustomer", t => t.CustomerID, cascadeDelete: true)
                .Index(t => t.CarID)
                .Index(t => t.CustomerID);
            
            CreateTable(
                "dbo.IdentityRole",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.IdentityUserRole",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(),
                        IdentityRole_Id = c.String(maxLength: 128),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.IdentityRole", t => t.IdentityRole_Id)
                .ForeignKey("dbo.ApplicationUser", t => t.ApplicationUser_Id)
                .Index(t => t.IdentityRole_Id)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.ApplicationUser",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.IdentityUserClaim",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ApplicationUser", t => t.ApplicationUser_Id)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.IdentityUserLogin",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        LoginProvider = c.String(),
                        ProviderKey = c.String(),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.ApplicationUser", t => t.ApplicationUser_Id)
                .Index(t => t.ApplicationUser_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.IdentityUserRole", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.IdentityUserLogin", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.IdentityUserClaim", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.IdentityUserRole", "IdentityRole_Id", "dbo.IdentityRole");
            DropForeignKey("dbo.DataTransaction", "CustomerID", "dbo.DataCustomer");
            DropForeignKey("dbo.DataTransaction", "CarID", "dbo.DataCar");
            DropIndex("dbo.IdentityUserLogin", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserClaim", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserRole", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserRole", new[] { "IdentityRole_Id" });
            DropIndex("dbo.DataTransaction", new[] { "CustomerID" });
            DropIndex("dbo.DataTransaction", new[] { "CarID" });
            DropTable("dbo.IdentityUserLogin");
            DropTable("dbo.IdentityUserClaim");
            DropTable("dbo.ApplicationUser");
            DropTable("dbo.IdentityUserRole");
            DropTable("dbo.IdentityRole");
            DropTable("dbo.DataTransaction");
            DropTable("dbo.DataCustomer");
            DropTable("dbo.DataCar");
        }
    }
}
