namespace Chatbot.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _9 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Travels", "PathId", "dbo.Paths");
            DropIndex("dbo.Travels", new[] { "PathId" });
            DropColumn("dbo.Travels", "PathId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Travels", "PathId", c => c.Int(nullable: false));
            CreateIndex("dbo.Travels", "PathId");
            AddForeignKey("dbo.Travels", "PathId", "dbo.Paths", "Id", cascadeDelete: true);
        }
    }
}
