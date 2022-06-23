namespace KhotruyenM.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdatetableStoriesindb : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Stories", "CategoryId", "dbo.Categories");
            DropIndex("dbo.Stories", new[] { "CategoryId" });
            RenameColumn(table: "dbo.Stories", name: "CategoryId", newName: "Category_CategoryId");
            AddColumn("dbo.Stories", "TypeStory", c => c.String());
            AlterColumn("dbo.Stories", "Category_CategoryId", c => c.Int());
            CreateIndex("dbo.Stories", "Category_CategoryId");
            AddForeignKey("dbo.Stories", "Category_CategoryId", "dbo.Categories", "CategoryId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Stories", "Category_CategoryId", "dbo.Categories");
            DropIndex("dbo.Stories", new[] { "Category_CategoryId" });
            AlterColumn("dbo.Stories", "Category_CategoryId", c => c.Int(nullable: false));
            DropColumn("dbo.Stories", "TypeStory");
            RenameColumn(table: "dbo.Stories", name: "Category_CategoryId", newName: "CategoryId");
            CreateIndex("dbo.Stories", "CategoryId");
            AddForeignKey("dbo.Stories", "CategoryId", "dbo.Categories", "CategoryId", cascadeDelete: true);
        }
    }
}
