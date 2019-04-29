namespace Chatbot.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _7 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Stops", "VehicleId", "dbo.Vehicles");
            DropForeignKey("dbo.Reservations", "PathId", "dbo.Paths");
            DropIndex("dbo.Stops", new[] { "VehicleId" });
            DropIndex("dbo.Reservations", new[] { "PathId" });
            AddColumn("dbo.Vehicles", "PathId", c => c.Int(nullable: false));
            CreateIndex("dbo.Vehicles", "PathId");
            AddForeignKey("dbo.Vehicles", "PathId", "dbo.Paths", "Id", cascadeDelete: false);
            DropColumn("dbo.Stops", "VehicleId");
            DropColumn("dbo.Reservations", "PathId");
            DropColumn("dbo.Travels", "MyProperty");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Travels", "MyProperty", c => c.Int(nullable: false));
            AddColumn("dbo.Reservations", "PathId", c => c.Int(nullable: false));
            AddColumn("dbo.Stops", "VehicleId", c => c.Int(nullable: false));
            DropForeignKey("dbo.Vehicles", "PathId", "dbo.Paths");
            DropIndex("dbo.Vehicles", new[] { "PathId" });
            DropColumn("dbo.Vehicles", "PathId");
            CreateIndex("dbo.Reservations", "PathId");
            CreateIndex("dbo.Stops", "VehicleId");
            AddForeignKey("dbo.Reservations", "PathId", "dbo.Paths", "Id", cascadeDelete: false);
            AddForeignKey("dbo.Stops", "VehicleId", "dbo.Vehicles", "Id", cascadeDelete: true);
        }
    }
}
