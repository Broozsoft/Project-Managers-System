namespace pmboard.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ScheduleFK : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Schedules", "ProjectmanagerId", "dbo.Projectmanagers");
            DropIndex("dbo.Schedules", new[] { "ProjectmanagerId" });
            DropPrimaryKey("dbo.Schedules");
            AddColumn("dbo.Projectmanagers", "ScheduleId", c => c.Int(nullable: false));
            AddColumn("dbo.Schedules", "ScheduleId", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.Schedules", "ScheduleId");
            CreateIndex("dbo.Schedules", "ScheduleId");
            AddForeignKey("dbo.Schedules", "ScheduleId", "dbo.Projectmanagers", "ID");
            DropColumn("dbo.Schedules", "Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Schedules", "Id", c => c.Int(nullable: false, identity: true));
            DropForeignKey("dbo.Schedules", "ScheduleId", "dbo.Projectmanagers");
            DropIndex("dbo.Schedules", new[] { "ScheduleId" });
            DropPrimaryKey("dbo.Schedules");
            DropColumn("dbo.Schedules", "ScheduleId");
            DropColumn("dbo.Projectmanagers", "ScheduleId");
            AddPrimaryKey("dbo.Schedules", "Id");
            CreateIndex("dbo.Schedules", "ProjectmanagerId");
            AddForeignKey("dbo.Schedules", "ProjectmanagerId", "dbo.Projectmanagers", "ID", cascadeDelete: true);
        }
    }
}
