namespace Chatbot.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _13 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Stops", "Path_Id", "dbo.Paths");
            DropIndex("dbo.Stops", new[] { "Path_Id" });
            DropColumn("dbo.Stops", "Path_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Stops", "Path_Id", c => c.Int());
            CreateIndex("dbo.Stops", "Path_Id");
            AddForeignKey("dbo.Stops", "Path_Id", "dbo.Paths", "Id");
        }
    }
}
