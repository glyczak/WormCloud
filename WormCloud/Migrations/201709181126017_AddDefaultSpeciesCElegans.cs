namespace WormCloud.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddDefaultSpeciesCElegans : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Species (Id, Name) VALUES (1, 'C. Elegans')");
        }
        
        public override void Down()
        {
        }
    }
}
