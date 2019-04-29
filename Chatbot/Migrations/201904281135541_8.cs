namespace Chatbot.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _8 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Travels", "ParticipantCount");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Travels", "ParticipantCount", c => c.Int(nullable: false));
        }
    }
}
