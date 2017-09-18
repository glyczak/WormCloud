namespace WormCloud.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCElegansToSpecies : DbMigration
    {
        public override void Up()
        {
            Sql("SET IDENTITY_INSERT Species ON");
            Sql("INSERT INTO Species (Id, Name) VALUES (1, 'C. Elegans')");
        }
        
        public override void Down()
        {
        }
    }
}
