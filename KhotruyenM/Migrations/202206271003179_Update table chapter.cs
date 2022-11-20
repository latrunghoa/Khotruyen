namespace KhotruyenM.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Updatetablechapter : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Chapters", "StoryId", "dbo.Stories");
            DropIndex("dbo.Chapters", new[] { "StoryId" });
            RenameColumn(table: "dbo.Chapters", name: "StoryId", newName: "Story_StoryId");
            AddColumn("dbo.Chapters", "StoryName", c => c.String());
            AlterColumn("dbo.Chapters", "Story_StoryId", c => c.Long());
            CreateIndex("dbo.Chapters", "Story_StoryId");
            AddForeignKey("dbo.Chapters", "Story_StoryId", "dbo.Stories", "StoryId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Chapters", "Story_StoryId", "dbo.Stories");
            DropIndex("dbo.Chapters", new[] { "Story_StoryId" });
            AlterColumn("dbo.Chapters", "Story_StoryId", c => c.Long(nullable: false));
            DropColumn("dbo.Chapters", "StoryName");
            RenameColumn(table: "dbo.Chapters", name: "Story_StoryId", newName: "StoryId");
            CreateIndex("dbo.Chapters", "StoryId");
            AddForeignKey("dbo.Chapters", "StoryId", "dbo.Stories", "StoryId", cascadeDelete: true);
        }
    }
}
