namespace pmboard.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _8 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Projects",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ProjectName = c.String(nullable: false),
                        FS = c.DateTime(),
                        G0 = c.DateTime(),
                        RDB = c.DateTime(),
                        G1 = c.DateTime(),
                        R2 = c.DateTime(),
                        G2 = c.DateTime(nullable: false),
                        R3 = c.DateTime(),
                        R4 = c.DateTime(),
                        G3 = c.DateTime(),
                        R5 = c.DateTime(),
                        R7 = c.DateTime(),
                        R8 = c.DateTime(),
                        G4 = c.DateTime(nullable: false),
                        END = c.DateTime(),
                        Status = c.String(),
                        KPI = c.Boolean(),
                        Comment = c.String(),
                        CategoryId = c.Int(nullable: false),
                        GateKeepersId = c.Int(nullable: false),
                        ProjectmanagerId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Categories", t => t.CategoryId, cascadeDelete: true)
                .ForeignKey("dbo.GateKeepers", t => t.GateKeepersId, cascadeDelete: true)
                .ForeignKey("dbo.Projectmanagers", t => t.ProjectmanagerId, cascadeDelete: true)
                .Index(t => t.CategoryId)
                .Index(t => t.GateKeepersId)
                .Index(t => t.ProjectmanagerId);
            
            CreateTable(
                "dbo.GateKeepers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Projectmanagers",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Projects", "ProjectmanagerId", "dbo.Projectmanagers");
            DropForeignKey("dbo.Projects", "GateKeepersId", "dbo.GateKeepers");
            DropForeignKey("dbo.Projects", "CategoryId", "dbo.Categories");
            DropIndex("dbo.Projects", new[] { "ProjectmanagerId" });
            DropIndex("dbo.Projects", new[] { "GateKeepersId" });
            DropIndex("dbo.Projects", new[] { "CategoryId" });
            DropTable("dbo.Projectmanagers");
            DropTable("dbo.GateKeepers");
            DropTable("dbo.Projects");
            DropTable("dbo.Categories");
        }
    }
}
