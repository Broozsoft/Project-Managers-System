namespace pmboard.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init6 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Schedules", "Monday", c => c.String());
            AddColumn("dbo.Schedules", "Tuesday", c => c.String());
            AddColumn("dbo.Schedules", "Wednesday", c => c.String());
            AddColumn("dbo.Schedules", "Thursday", c => c.String());
            AddColumn("dbo.Schedules", "Friday", c => c.String());
            DropColumn("dbo.Schedules", "date");
            DropColumn("dbo.Schedules", "status");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Schedules", "status", c => c.String());
            AddColumn("dbo.Schedules", "date", c => c.DateTime(nullable: false));
            DropColumn("dbo.Schedules", "Friday");
            DropColumn("dbo.Schedules", "Thursday");
            DropColumn("dbo.Schedules", "Wednesday");
            DropColumn("dbo.Schedules", "Tuesday");
            DropColumn("dbo.Schedules", "Monday");
        }
    }
}
