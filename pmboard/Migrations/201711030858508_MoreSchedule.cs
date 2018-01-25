namespace pmboard.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MoreSchedule : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Schedules", "ProjectmanagerId");
            RenameColumn(table: "dbo.Schedules", name: "ScheduleId", newName: "ProjectmanagerId");
            RenameIndex(table: "dbo.Schedules", name: "IX_ScheduleId", newName: "IX_ProjectmanagerId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Schedules", name: "IX_ProjectmanagerId", newName: "IX_ScheduleId");
            RenameColumn(table: "dbo.Schedules", name: "ProjectmanagerId", newName: "ScheduleId");
            AddColumn("dbo.Schedules", "ProjectmanagerId", c => c.Int(nullable: false));
        }
    }
}
