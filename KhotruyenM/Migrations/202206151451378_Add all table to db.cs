namespace KhotruyenM.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Addalltabletodb : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        CategoryId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 255),
                        Metatitle = c.String(maxLength: 255),
                        CreateDate = c.DateTime(nullable: false),
                        CreateBy = c.String(),
                    })
                .PrimaryKey(t => t.CategoryId);
            
            CreateTable(
                "dbo.Chapters",
                c => new
                    {
                        ChapterId = c.Long(nullable: false, identity: true),
                        ChapterNumber = c.String(nullable: false, maxLength: 255),
                        Name = c.String(nullable: false, maxLength: 255),
                        CountView = c.Int(nullable: false),
                        Content = c.String(nullable: false),
                        CreateDate = c.DateTime(nullable: false),
                        StoryId = c.Long(nullable: false),
                        Useries_UserId = c.Long(),
                    })
                .PrimaryKey(t => t.ChapterId)
                .ForeignKey("dbo.Stories", t => t.StoryId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.Useries_UserId)
                .Index(t => t.StoryId)
                .Index(t => t.Useries_UserId);
            
            CreateTable(
                "dbo.Stories",
                c => new
                    {
                        StoryId = c.Long(nullable: false, identity: true),
                        vnName = c.String(nullable: false),
                        cnName = c.String(),
                        cnLink = c.String(),
                        Images = c.String(),
                        Author = c.String(nullable: false),
                        Information = c.String(nullable: false),
                        CountView = c.Int(nullable: false),
                        Rating = c.Single(nullable: false),
                        CreateDate = c.DateTime(nullable: false),
                        UpdateDate = c.DateTime(nullable: false),
                        CategoryId = c.Int(nullable: false),
                        Useries_UserId = c.Long(),
                    })
                .PrimaryKey(t => t.StoryId)
                .ForeignKey("dbo.Categories", t => t.CategoryId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.Useries_UserId)
                .Index(t => t.CategoryId)
                .Index(t => t.Useries_UserId);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        UserId = c.Long(nullable: false, identity: true),
                        UserName = c.String(nullable: false, maxLength: 100),
                        Password = c.String(nullable: false, maxLength: 30),
                        DisplayName = c.String(),
                        Email = c.String(),
                        Avatar = c.String(),
                        CreateDate = c.DateTime(nullable: false),
                        RoleID = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.Roles", t => t.RoleID, cascadeDelete: true)
                .Index(t => t.RoleID);
            
            CreateTable(
                "dbo.Roles",
                c => new
                    {
                        RoleId = c.Long(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.RoleId);
            
            CreateTable(
                "dbo.Comments",
                c => new
                    {
                        CommentId = c.Long(nullable: false, identity: true),
                        Content = c.String(nullable: false),
                        CreateDate = c.DateTime(nullable: false),
                        StoryId = c.Long(nullable: false),
                        Useries_UserId = c.Long(),
                    })
                .PrimaryKey(t => t.CommentId)
                .ForeignKey("dbo.Stories", t => t.StoryId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.Useries_UserId)
                .Index(t => t.StoryId)
                .Index(t => t.Useries_UserId);
            
            CreateTable(
                "dbo.Histories",
                c => new
                    {
                        HistoryId = c.Long(nullable: false, identity: true),
                        LocationIP = c.String(maxLength: 50),
                        DateView = c.DateTime(nullable: false),
                        ChapterId = c.Long(nullable: false),
                        Useries_UserId = c.Long(),
                    })
                .PrimaryKey(t => t.HistoryId)
                .ForeignKey("dbo.Chapters", t => t.ChapterId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.Useries_UserId)
                .Index(t => t.ChapterId)
                .Index(t => t.Useries_UserId);
            
            CreateTable(
                "dbo.Reports",
                c => new
                    {
                        ReportId = c.Long(nullable: false, identity: true),
                        Content = c.String(nullable: false),
                        CreateDate = c.DateTime(nullable: false),
                        ChapterId = c.Long(nullable: false),
                        Useries_UserId = c.Long(),
                    })
                .PrimaryKey(t => t.ReportId)
                .ForeignKey("dbo.Chapters", t => t.ChapterId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.Useries_UserId)
                .Index(t => t.ChapterId)
                .Index(t => t.Useries_UserId);
            
            
            CreateTable(
                "dbo.UserFollows",
                c => new
                    {
                        UserId = c.Long(nullable: false),
                        StoryId = c.Long(nullable: false),
                    })
                .PrimaryKey(t => new { t.UserId, t.StoryId })
                .ForeignKey("dbo.Stories", t => t.StoryId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.StoryId);
            
            CreateTable(
                "dbo.UserRatings",
                c => new
                    {
                        UserId = c.Long(nullable: false),
                        StoryId = c.Long(nullable: false),
                        LocationIP = c.String(maxLength: 50),
                        Rating = c.Single(nullable: false),
                        CreateDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => new { t.UserId, t.StoryId })
                .ForeignKey("dbo.Stories", t => t.StoryId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.StoryId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserRatings", "UserId", "dbo.Users");
            DropForeignKey("dbo.UserRatings", "StoryId", "dbo.Stories");
            DropForeignKey("dbo.UserFollows", "UserId", "dbo.Users");
            DropForeignKey("dbo.UserFollows", "StoryId", "dbo.Stories");
            DropForeignKey("dbo.Reports", "Useries_UserId", "dbo.Users");
            DropForeignKey("dbo.Reports", "ChapterId", "dbo.Chapters");
            DropForeignKey("dbo.Histories", "Useries_UserId", "dbo.Users");
            DropForeignKey("dbo.Histories", "ChapterId", "dbo.Chapters");
            DropForeignKey("dbo.Comments", "Useries_UserId", "dbo.Users");
            DropForeignKey("dbo.Comments", "StoryId", "dbo.Stories");
            DropForeignKey("dbo.Chapters", "Useries_UserId", "dbo.Users");
            DropForeignKey("dbo.Chapters", "StoryId", "dbo.Stories");
            DropForeignKey("dbo.Stories", "Useries_UserId", "dbo.Users");
            DropForeignKey("dbo.Users", "RoleID", "dbo.Roles");
            DropForeignKey("dbo.Stories", "CategoryId", "dbo.Categories");
            DropIndex("dbo.UserRatings", new[] { "StoryId" });
            DropIndex("dbo.UserRatings", new[] { "UserId" });
            DropIndex("dbo.UserFollows", new[] { "StoryId" });
            DropIndex("dbo.UserFollows", new[] { "UserId" });
            DropIndex("dbo.Reports", new[] { "Useries_UserId" });
            DropIndex("dbo.Reports", new[] { "ChapterId" });
            DropIndex("dbo.Histories", new[] { "Useries_UserId" });
            DropIndex("dbo.Histories", new[] { "ChapterId" });
            DropIndex("dbo.Comments", new[] { "Useries_UserId" });
            DropIndex("dbo.Comments", new[] { "StoryId" });
            DropIndex("dbo.Users", new[] { "RoleID" });
            DropIndex("dbo.Stories", new[] { "Useries_UserId" });
            DropIndex("dbo.Stories", new[] { "CategoryId" });
            DropIndex("dbo.Chapters", new[] { "Useries_UserId" });
            DropIndex("dbo.Chapters", new[] { "StoryId" });
            DropTable("dbo.UserRatings");
            DropTable("dbo.UserFollows");
            DropTable("dbo.Reports");
            DropTable("dbo.Histories");
            DropTable("dbo.Comments");
            DropTable("dbo.Roles");
            DropTable("dbo.Users");
            DropTable("dbo.Stories");
            DropTable("dbo.Chapters");
            DropTable("dbo.Categories");
        }
    }
}
