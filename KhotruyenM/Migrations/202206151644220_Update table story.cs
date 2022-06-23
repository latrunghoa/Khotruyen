namespace KhotruyenM.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Updatetablestory : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Stories", "Useries_UserId", "dbo.Users");
            DropIndex("dbo.Stories", new[] { "Useries_UserId" });
            DropColumn("dbo.Stories", "Useries_UserId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Stories", "Useries_UserId", c => c.Long());
            CreateIndex("dbo.Stories", "Useries_UserId");
            AddForeignKey("dbo.Stories", "Useries_UserId", "dbo.Users", "UserId");
        }
    }
}
