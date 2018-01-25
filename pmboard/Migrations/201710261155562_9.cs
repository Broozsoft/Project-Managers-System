namespace pmboard.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _9 : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Projects", name: "GateKeepersId", newName: "GateKeeperId");
            RenameIndex(table: "dbo.Projects", name: "IX_GateKeepersId", newName: "IX_GateKeeperId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Projects", name: "IX_GateKeeperId", newName: "IX_GateKeepersId");
            RenameColumn(table: "dbo.Projects", name: "GateKeeperId", newName: "GateKeepersId");
        }
    }
}
