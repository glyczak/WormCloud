namespace WormCloud.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MovedSourceFromSampleToStrain : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Strains", "Source", c => c.String());
            DropColumn("dbo.Samples", "CreatedBy");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Samples", "CreatedBy", c => c.String());
            DropColumn("dbo.Strains", "Source");
        }
    }
}
