namespace Chatbot.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _10 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Stops", "PathId", "dbo.Paths");
            AddColumn("dbo.Stops", "PathStopId", c => c.Int(nullable: false));
            AddColumn("dbo.Stops", "Path_Id", c => c.Int());
            CreateIndex("dbo.Stops", "PathStopId");
            CreateIndex("dbo.Stops", "Path_Id");
            AddForeignKey("dbo.Stops", "PathStopId", "dbo.Paths", "Id", cascadeDelete: false);
            AddForeignKey("dbo.Stops", "Path_Id", "dbo.Paths", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Stops", "Path_Id", "dbo.Paths");
            DropForeignKey("dbo.Stops", "PathStopId", "dbo.Paths");
            DropIndex("dbo.Stops", new[] { "Path_Id" });
            DropIndex("dbo.Stops", new[] { "PathStopId" });
            DropColumn("dbo.Stops", "Path_Id");
            DropColumn("dbo.Stops", "PathStopId");
            AddForeignKey("dbo.Stops", "PathId", "dbo.Paths", "Id", cascadeDelete: true);
        }
    }
}
