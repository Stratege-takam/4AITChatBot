namespace Chatbot.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _6 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Reservations", "ParticipantId", "dbo.Participants");
            DropForeignKey("dbo.Participants", "Vehicle_Id", "dbo.Vehicles");
            DropForeignKey("dbo.Reservations", "StandardId", "dbo.Standards");
            DropForeignKey("dbo.HistoryStandards", "StandardId", "dbo.Standards");
            DropForeignKey("dbo.HistoryStandards", "Transport_Id", "dbo.Vehicles");
            DropIndex("dbo.HistoryStandards", new[] { "StandardId" });
            DropIndex("dbo.HistoryStandards", new[] { "Transport_Id" });
            DropIndex("dbo.Reservations", new[] { "ParticipantId" });
            DropIndex("dbo.Reservations", new[] { "StandardId" });
            DropIndex("dbo.Participants", new[] { "Vehicle_Id" });
            AddColumn("dbo.Reservations", "Participant", c => c.String());
            AddColumn("dbo.Reservations", "Standard", c => c.String());
            AddColumn("dbo.Travels", "ParticipantCount", c => c.Int(nullable: false));
            AddColumn("dbo.Travels", "TravelStart", c => c.DateTime(nullable: false));
            AddColumn("dbo.Travels", "TravelEnd", c => c.DateTime(nullable: false));
            AddColumn("dbo.Travels", "MyProperty", c => c.Int(nullable: false));
            DropColumn("dbo.Reservations", "ParticipantId");
            DropColumn("dbo.Reservations", "StandardId");
            DropColumn("dbo.Reservations", "State");
            DropColumn("dbo.Vehicles", "concessionary");
            DropColumn("dbo.Stops", "Cost");
            DropColumn("dbo.Stops", "StartTime");
            DropColumn("dbo.Stops", "EndTime");
            DropColumn("dbo.Travels", "TravelDate");
            DropTable("dbo.HistoryStandards");
            DropTable("dbo.Standards");
            DropTable("dbo.Participants");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Participants",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        TravelDocument = c.String(),
                        VehiculeId = c.Int(nullable: false),
                        Role = c.String(),
                        Vehicle_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Standards",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.HistoryStandards",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PlaceCount = c.Int(nullable: false),
                        TansportId = c.Int(nullable: false),
                        StandardId = c.Int(nullable: false),
                        Transport_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Travels", "TravelDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Stops", "EndTime", c => c.DateTime(nullable: false));
            AddColumn("dbo.Stops", "StartTime", c => c.DateTime(nullable: false));
            AddColumn("dbo.Stops", "Cost", c => c.Double(nullable: false));
            AddColumn("dbo.Vehicles", "concessionary", c => c.String());
            AddColumn("dbo.Reservations", "State", c => c.Boolean(nullable: false));
            AddColumn("dbo.Reservations", "StandardId", c => c.Int(nullable: false));
            AddColumn("dbo.Reservations", "ParticipantId", c => c.Int(nullable: false));
            DropColumn("dbo.Travels", "MyProperty");
            DropColumn("dbo.Travels", "TravelEnd");
            DropColumn("dbo.Travels", "TravelStart");
            DropColumn("dbo.Travels", "ParticipantCount");
            DropColumn("dbo.Reservations", "Standard");
            DropColumn("dbo.Reservations", "Participant");
            CreateIndex("dbo.Participants", "Vehicle_Id");
            CreateIndex("dbo.Reservations", "StandardId");
            CreateIndex("dbo.Reservations", "ParticipantId");
            CreateIndex("dbo.HistoryStandards", "Transport_Id");
            CreateIndex("dbo.HistoryStandards", "StandardId");
            AddForeignKey("dbo.HistoryStandards", "Transport_Id", "dbo.Vehicles", "Id");
            AddForeignKey("dbo.HistoryStandards", "StandardId", "dbo.Standards", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Reservations", "StandardId", "dbo.Standards", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Participants", "Vehicle_Id", "dbo.Vehicles", "Id");
            AddForeignKey("dbo.Reservations", "ParticipantId", "dbo.Participants", "Id", cascadeDelete: true);
        }
    }
}
