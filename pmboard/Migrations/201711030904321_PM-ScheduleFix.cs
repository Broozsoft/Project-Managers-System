namespace pmboard.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PMScheduleFix : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Projectmanagers", "ScheduleId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Projectmanagers", "ScheduleId", c => c.Int(nullable: false));
        }
    }
}
