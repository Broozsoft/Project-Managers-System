namespace pmboard.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Projects", "GateKeepers_Id", "dbo.GateKeepers");
            DropIndex("dbo.Projects", new[] { "GateKeepers_Id" });
            DropColumn("dbo.Projects", "GateKeeperId");
            RenameColumn(table: "dbo.Projects", name: "GateKeepers_Id", newName: "GateKeeperId");
            AlterColumn("dbo.Projects", "GateKeeperId", c => c.Int(nullable: false));
            CreateIndex("dbo.Projects", "GateKeeperId");
            AddForeignKey("dbo.Projects", "GateKeeperId", "dbo.GateKeepers", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Projects", "GateKeeperId", "dbo.GateKeepers");
            DropIndex("dbo.Projects", new[] { "GateKeeperId" });
            AlterColumn("dbo.Projects", "GateKeeperId", c => c.Int());
            RenameColumn(table: "dbo.Projects", name: "GateKeeperId", newName: "GateKeepers_Id");
            AddColumn("dbo.Projects", "GateKeeperId", c => c.Int(nullable: false));
            CreateIndex("dbo.Projects", "GateKeepers_Id");
            AddForeignKey("dbo.Projects", "GateKeepers_Id", "dbo.GateKeepers", "Id");
        }
    }
}
