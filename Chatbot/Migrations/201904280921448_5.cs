namespace Chatbot.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _5 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Roles", "ParticipantId", "dbo.Participants");
            DropForeignKey("dbo.Roles", "TransportId", "dbo.Vehicles");
            DropIndex("dbo.Roles", new[] { "ParticipantId" });
            DropIndex("dbo.Roles", new[] { "TransportId" });
            AddColumn("dbo.Participants", "VehiculeId", c => c.Int(nullable: false));
            AddColumn("dbo.Participants", "Role", c => c.String());
            AddColumn("dbo.Participants", "Vehicle_Id", c => c.Int());
            CreateIndex("dbo.Participants", "Vehicle_Id");
            AddForeignKey("dbo.Participants", "Vehicle_Id", "dbo.Vehicles", "Id");
            DropTable("dbo.Roles");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Roles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        ParticipantId = c.Int(nullable: false),
                        TransportId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            DropForeignKey("dbo.Participants", "Vehicle_Id", "dbo.Vehicles");
            DropIndex("dbo.Participants", new[] { "Vehicle_Id" });
            DropColumn("dbo.Participants", "Vehicle_Id");
            DropColumn("dbo.Participants", "Role");
            DropColumn("dbo.Participants", "VehiculeId");
            CreateIndex("dbo.Roles", "TransportId");
            CreateIndex("dbo.Roles", "ParticipantId");
            AddForeignKey("dbo.Roles", "TransportId", "dbo.Vehicles", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Roles", "ParticipantId", "dbo.Participants", "Id", cascadeDelete: true);
        }
    }
}
