namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddColumnEndBooking : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Reservas", "FechaFinReserva", c => c.DateTime(nullable: false, precision: 0, storeType: "datetime2"));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Reservas", "FechaFinReserva");
        }
    }
}
