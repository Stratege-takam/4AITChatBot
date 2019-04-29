namespace Chatbot.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _12 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Stops", "Path_Id", c => c.Int());
            CreateIndex("dbo.Stops", "Path_Id");
            AddForeignKey("dbo.Stops", "Path_Id", "dbo.Paths", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Stops", "Path_Id", "dbo.Paths");
            DropIndex("dbo.Stops", new[] { "Path_Id" });
            DropColumn("dbo.Stops", "Path_Id");
        }
    }
}
