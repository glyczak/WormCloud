namespace WormCloud.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedSpeciesStrainAndSampleModels : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Samples",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        StrainId = c.Int(nullable: false),
                        CreatedBy = c.String(),
                        CheckedOut = c.Boolean(nullable: false),
                        Notes = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Strains", t => t.StrainId, cascadeDelete: true)
                .Index(t => t.StrainId);
            
            CreateTable(
                "dbo.Strains",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SpeciesId = c.Int(nullable: false),
                        Name = c.String(nullable: false),
                        Genotype = c.String(nullable: false),
                        Notes = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Species", t => t.SpeciesId, cascadeDelete: true)
                .Index(t => t.SpeciesId);
            
            CreateTable(
                "dbo.Species",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Samples", "StrainId", "dbo.Strains");
            DropForeignKey("dbo.Strains", "SpeciesId", "dbo.Species");
            DropIndex("dbo.Strains", new[] { "SpeciesId" });
            DropIndex("dbo.Samples", new[] { "StrainId" });
            DropTable("dbo.Species");
            DropTable("dbo.Strains");
            DropTable("dbo.Samples");
        }
    }
}
