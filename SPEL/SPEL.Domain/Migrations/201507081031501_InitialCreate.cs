namespace SPEL.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Betaling",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        BetalingTypeID = c.Int(nullable: false),
                        LidID = c.Int(nullable: false),
                        Betaald = c.Boolean(nullable: false),
                        Bedrag = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.BetalingType", t => t.BetalingTypeID, cascadeDelete: true)
                .ForeignKey("dbo.Lid", t => t.LidID, cascadeDelete: true)
                .Index(t => t.BetalingTypeID)
                .Index(t => t.LidID);
            
            CreateTable(
                "dbo.BetalingType",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Bedrag = c.Decimal(nullable: false, precision: 18, scale: 2),
                        BetalingTypeNaam = c.String(),
                        SportklasseID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Sportklasse", t => t.SportklasseID)
                .Index(t => t.SportklasseID);
            
            CreateTable(
                "dbo.Sportklasse",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        naam = c.String(nullable: false),
                        indeling = c.Int(nullable: false),
                        SportID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Sport", t => t.SportID, cascadeDelete: true)
                .Index(t => t.SportID);
            
            CreateTable(
                "dbo.Sport",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        naam = c.String(nullable: false),
                        typeSport = c.Int(nullable: false),
                        beschrijving = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Lid",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Naam = c.String(nullable: false),
                        GebDatum = c.DateTime(nullable: false),
                        Geslacht = c.Int(nullable: false),
                        Woonplaats = c.String(),
                        Adres = c.String(),
                        Email = c.String(nullable: false),
                        Telnr = c.Int(),
                        PassID = c.Int(),
                        Pasfoto = c.String(),
                        ImageData = c.Binary(),
                        ImageMimeType = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Inschrijving",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        datumInschrijving = c.DateTime(nullable: false),
                        datumUitschrijving = c.DateTime(),
                        lidId = c.Int(nullable: false),
                        sportklasseId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Lid", t => t.lidId, cascadeDelete: true)
                .ForeignKey("dbo.Sportklasse", t => t.sportklasseId, cascadeDelete: true)
                .Index(t => t.lidId)
                .Index(t => t.sportklasseId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Inschrijving", "sportklasseId", "dbo.Sportklasse");
            DropForeignKey("dbo.Inschrijving", "lidId", "dbo.Lid");
            DropForeignKey("dbo.Betaling", "LidID", "dbo.Lid");
            DropForeignKey("dbo.Betaling", "BetalingTypeID", "dbo.BetalingType");
            DropForeignKey("dbo.BetalingType", "SportklasseID", "dbo.Sportklasse");
            DropForeignKey("dbo.Sportklasse", "SportID", "dbo.Sport");
            DropIndex("dbo.Inschrijving", new[] { "sportklasseId" });
            DropIndex("dbo.Inschrijving", new[] { "lidId" });
            DropIndex("dbo.Sportklasse", new[] { "SportID" });
            DropIndex("dbo.BetalingType", new[] { "SportklasseID" });
            DropIndex("dbo.Betaling", new[] { "LidID" });
            DropIndex("dbo.Betaling", new[] { "BetalingTypeID" });
            DropTable("dbo.Inschrijving");
            DropTable("dbo.Lid");
            DropTable("dbo.Sport");
            DropTable("dbo.Sportklasse");
            DropTable("dbo.BetalingType");
            DropTable("dbo.Betaling");
        }
    }
}
