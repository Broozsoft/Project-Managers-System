namespace pmboard.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class GoldStar : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.GoldStars",
                c => new
                    {
                        ProjectId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ProjectId)
                .ForeignKey("dbo.Projects", t => t.ProjectId)
                .Index(t => t.ProjectId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.GoldStars", "ProjectId", "dbo.Projects");
            DropIndex("dbo.GoldStars", new[] { "ProjectId" });
            DropTable("dbo.GoldStars");
        }
    }
}
