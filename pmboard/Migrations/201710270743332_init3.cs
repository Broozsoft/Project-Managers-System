namespace pmboard.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init3 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Schedules",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        date = c.DateTime(nullable: false),
                        status = c.String(),
                        ProjectmanagerId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Projectmanagers", t => t.ProjectmanagerId, cascadeDelete: true)
                .Index(t => t.ProjectmanagerId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Schedules", "ProjectmanagerId", "dbo.Projectmanagers");
            DropIndex("dbo.Schedules", new[] { "ProjectmanagerId" });
            DropTable("dbo.Schedules");
        }
    }
}
