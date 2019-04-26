namespace Chatbot.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Facts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Question = c.String(),
                        Rule_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Rules", t => t.Rule_Id)
                .Index(t => t.Rule_Id);
            
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
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Standards", t => t.StandardId, cascadeDelete: true)
                .ForeignKey("dbo.Vehicles", t => t.Transport_Id)
                .Index(t => t.StandardId)
                .Index(t => t.Transport_Id);
            
            CreateTable(
                "dbo.Standards",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Reservations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ParticipantId = c.Int(nullable: false),
                        TravelId = c.Int(nullable: false),
                        StandardId = c.Int(nullable: false),
                        PathId = c.Int(nullable: false),
                        ReversationDate = c.DateTime(nullable: false),
                        TravelCost = c.Double(nullable: false),
                        State = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Participants", t => t.ParticipantId, cascadeDelete: true)
                .ForeignKey("dbo.Paths", t => t.PathId, cascadeDelete: false)
                .ForeignKey("dbo.Standards", t => t.StandardId, cascadeDelete: true)
                .ForeignKey("dbo.Travels", t => t.TravelId, cascadeDelete: true)
                .Index(t => t.ParticipantId)
                .Index(t => t.TravelId)
                .Index(t => t.StandardId)
                .Index(t => t.PathId);
            
            CreateTable(
                "dbo.Participants",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        TravelDocument = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Roles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        ParticipantId = c.Int(nullable: false),
                        TransportId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Participants", t => t.ParticipantId, cascadeDelete: true)
                .ForeignKey("dbo.Vehicles", t => t.TransportId, cascadeDelete: true)
                .Index(t => t.ParticipantId)
                .Index(t => t.TransportId);
            
            CreateTable(
                "dbo.Vehicles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Type = c.String(),
                        CompanyName = c.String(),
                        concessionary = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Stops",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        VehicleId = c.Int(nullable: false),
                        PathId = c.Int(nullable: false),
                        Cost = c.Double(nullable: false),
                        StartTime = c.DateTime(nullable: false),
                        EndTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Paths", t => t.PathId, cascadeDelete: true)
                .ForeignKey("dbo.Vehicles", t => t.VehicleId, cascadeDelete: true)
                .Index(t => t.VehicleId)
                .Index(t => t.PathId);
            
            CreateTable(
                "dbo.Paths",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Start = c.String(),
                        End = c.String(),
                        Distance = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Travels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TransportId = c.Int(nullable: false),
                        PathId = c.Int(nullable: false),
                        TravelDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Paths", t => t.PathId, cascadeDelete: true)
                .ForeignKey("dbo.Vehicles", t => t.TransportId, cascadeDelete: true)
                .Index(t => t.TransportId)
                .Index(t => t.PathId);
            
            CreateTable(
                "dbo.Rules",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Facts", "Rule_Id", "dbo.Rules");
            DropForeignKey("dbo.HistoryStandards", "Transport_Id", "dbo.Vehicles");
            DropForeignKey("dbo.HistoryStandards", "StandardId", "dbo.Standards");
            DropForeignKey("dbo.Travels", "TransportId", "dbo.Vehicles");
            DropForeignKey("dbo.Reservations", "TravelId", "dbo.Travels");
            DropForeignKey("dbo.Travels", "PathId", "dbo.Paths");
            DropForeignKey("dbo.Reservations", "StandardId", "dbo.Standards");
            DropForeignKey("dbo.Reservations", "PathId", "dbo.Paths");
            DropForeignKey("dbo.Stops", "VehicleId", "dbo.Vehicles");
            DropForeignKey("dbo.Stops", "PathId", "dbo.Paths");
            DropForeignKey("dbo.Roles", "TransportId", "dbo.Vehicles");
            DropForeignKey("dbo.Roles", "ParticipantId", "dbo.Participants");
            DropForeignKey("dbo.Reservations", "ParticipantId", "dbo.Participants");
            DropIndex("dbo.Travels", new[] { "PathId" });
            DropIndex("dbo.Travels", new[] { "TransportId" });
            DropIndex("dbo.Stops", new[] { "PathId" });
            DropIndex("dbo.Stops", new[] { "VehicleId" });
            DropIndex("dbo.Roles", new[] { "TransportId" });
            DropIndex("dbo.Roles", new[] { "ParticipantId" });
            DropIndex("dbo.Reservations", new[] { "PathId" });
            DropIndex("dbo.Reservations", new[] { "StandardId" });
            DropIndex("dbo.Reservations", new[] { "TravelId" });
            DropIndex("dbo.Reservations", new[] { "ParticipantId" });
            DropIndex("dbo.HistoryStandards", new[] { "Transport_Id" });
            DropIndex("dbo.HistoryStandards", new[] { "StandardId" });
            DropIndex("dbo.Facts", new[] { "Rule_Id" });
            DropTable("dbo.Rules");
            DropTable("dbo.Travels");
            DropTable("dbo.Paths");
            DropTable("dbo.Stops");
            DropTable("dbo.Vehicles");
            DropTable("dbo.Roles");
            DropTable("dbo.Participants");
            DropTable("dbo.Reservations");
            DropTable("dbo.Standards");
            DropTable("dbo.HistoryStandards");
            DropTable("dbo.Facts");
        }
    }
}
