namespace pmboard.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init61 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Projects", "ProgressString", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Projects", "ProgressString");
        }
    }
}
