namespace Project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Second : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.BusStations", "Departure", c => c.String(nullable: false));
            AlterColumn("dbo.BusStations", "Arrival", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.BusStations", "Arrival", c => c.Int(nullable: false));
            AlterColumn("dbo.BusStations", "Departure", c => c.Int(nullable: false));
        }
    }
}
