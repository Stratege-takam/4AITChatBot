namespace Chatbot.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _3 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Facts", "Rule_Id", "dbo.Rules");
            DropIndex("dbo.Facts", new[] { "Rule_Id" });
            CreateTable(
                "dbo.RuleFacts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FactId = c.Int(nullable: false),
                        RuleId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Facts", t => t.FactId, cascadeDelete: true)
                .ForeignKey("dbo.Rules", t => t.RuleId, cascadeDelete: true)
                .Index(t => t.FactId)
                .Index(t => t.RuleId);
            
            DropColumn("dbo.Facts", "Rule_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Facts", "Rule_Id", c => c.Int());
            DropForeignKey("dbo.RuleFacts", "RuleId", "dbo.Rules");
            DropForeignKey("dbo.RuleFacts", "FactId", "dbo.Facts");
            DropIndex("dbo.RuleFacts", new[] { "RuleId" });
            DropIndex("dbo.RuleFacts", new[] { "FactId" });
            DropTable("dbo.RuleFacts");
            CreateIndex("dbo.Facts", "Rule_Id");
            AddForeignKey("dbo.Facts", "Rule_Id", "dbo.Rules", "Id");
        }
    }
}
