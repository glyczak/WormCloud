namespace WormCloud.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddBoxAndLocationToSamples : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Samples", "Box", c => c.Int(nullable: false));
            AddColumn("dbo.Samples", "Location", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Samples", "Location");
            DropColumn("dbo.Samples", "Box");
        }
    }
}
