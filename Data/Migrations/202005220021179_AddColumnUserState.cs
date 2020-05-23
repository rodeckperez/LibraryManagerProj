namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddColumnUserState : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Usuarios", "Estado", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Usuarios", "Estado");
        }
    }
}
