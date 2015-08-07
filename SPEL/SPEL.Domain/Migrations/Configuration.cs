using SPEL.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;

namespace SPEL.Domain.Migrations
{
    

    internal sealed class Configuration : DbMigrationsConfiguration<SPEL.Domain.Concrete.SPELContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(SPEL.Domain.Concrete.SPELContext context)
        {
            

            var leden = new List<Lid>
            {
                new Lid { Naam = "Hans van Roon", Adres="Achter 't Hof 3C", Email="hansvanroon@hetnet.nl", GebDatum = DateTime.Parse("5-10-1992"), Geslacht= Geslacht.man, Woonplaats= "Hoeven"},                new Lid { Naam = "Hans van Roon", Adres="Achter 't Hof 3C", Email="hansvanroon@hetnet.nl", GebDatum = DateTime.Parse("5-10-1992"), Geslacht= Geslacht.man, Woonplaats= "Hoeven"},
                new Lid { Naam = "Isaac Newton", Adres="Longstreet 5", Email="Isaac@hetnet.nl", GebDatum = DateTime.Parse("5-10-1999"), Geslacht= Geslacht.man, Woonplaats= "Breda"},
                new Lid { Naam = "Albert Einstein", Adres="Emsee Square 12", Email="nuclear@hetnet.nl", GebDatum = DateTime.Parse("5-10-2000"), Geslacht= Geslacht.man, Woonplaats= "Hoeven"},
                new Lid { Naam = "Alfred Nobel", Adres="Teeëntéstraat 15", Email="vury@hetnet.nl", GebDatum = DateTime.Parse("5-10-1999"), Geslacht= Geslacht.man, Woonplaats= "Breda"},
                new Lid { Naam = "Marie Qury", Adres="Molleystreet 12", Email="molletje@hetnet.nl", GebDatum = DateTime.Parse("5-10-2010"), Geslacht= Geslacht.vrouw, Woonplaats= "Breda"},
                new Lid { Naam = "Nicolaz Tesla", Adres="Gelijkstraat 25", Email="Tesla@hetnet.nl", GebDatum = DateTime.Parse("5-01-2005"), Geslacht= Geslacht.vrouw, Woonplaats= "Breda"},
                new Lid { Naam = "Hans van Roon", Adres="Achter 't Hof 3C", Email="ingrid@hetnet.nl", GebDatum = DateTime.Parse("5-02-2002"), Geslacht= Geslacht.vrouw, Woonplaats= "Oosterhout"},
                new Lid { Naam = "Bert Rue", Adres="Sésamstraat 12", Email="kees@hetnet.nl", GebDatum = DateTime.Parse("5-05-2001"), Geslacht= Geslacht.man, Woonplaats= "Oosterhout"},
                new Lid { Naam = "Ernie Rue", Adres="Sésamstraat 12", Email="henk@hetnet.nl", GebDatum = DateTime.Parse("5-08-1966"), Geslacht= Geslacht.man, Woonplaats= "Oosterhout"},
                new Lid { Naam = "Dora Exploré", Adres="Waldostraat 5", Email="hennie@hetnet.nl", GebDatum = DateTime.Parse("5-06-1999"), Geslacht= Geslacht.vrouw, Woonplaats= "Oosterhout"},
                new Lid { Naam = "Stanley Mes", Adres="Vorstraat 18", Email="simone@hetnet.nl", GebDatum = DateTime.Parse("5-09-1998"), Geslacht= Geslacht.vrouw, Woonplaats= "Oosterhout"},
                new Lid { Naam = "Hagrid", Adres="grootestraat 12", Email="hagrid@hetnet.nl", GebDatum = DateTime.Parse("5-12-2002"), Geslacht= Geslacht.man, Woonplaats= "Etten-Leur"},
                new Lid { Naam = "Harry Potter", Adres="weesstraat 20", Email="harry@hetnet.nl", GebDatum = DateTime.Parse("5-12-2007"), Geslacht= Geslacht.man, Woonplaats= "Etten-Leur"},
                new Lid { Naam = "Draco Malfidus", Adres="snobstraat 1", Email="malfidus@hetnet.nl", GebDatum = DateTime.Parse("5-08-2009"), Geslacht= Geslacht.man, Woonplaats= "Etten-Leur"},
                new Lid { Naam = "Ron Wemel", Adres="sloeberstraat 12", Email="wemel@hetnet.nl", GebDatum = DateTime.Parse("5-09-2011"), Geslacht= Geslacht.man, Woonplaats= "Etten-Leur"}
            };

            leden.ForEach(s => context.Leden.AddOrUpdate(l => l.Email, s));
            context.SaveChanges();

            var sporten = new List<Sport>{
                new Sport { naam = "Voetbal", typeSport= TypeSport.Balsport},
                new Sport { naam = "Handbal", typeSport= TypeSport.Balsport},
                new Sport { naam = "Korfbal", typeSport= TypeSport.Balsport},
                new Sport { naam = "Tourfietsen", typeSport= TypeSport.Fietssport},
                new Sport { naam = "Crossfietsen", typeSport= TypeSport.Fietssport},
                new Sport { naam = "Wielrenners", typeSport= TypeSport.Fietssport}
            };

            sporten.ForEach(s => context.sporten.AddOrUpdate(p => p.naam, s));
            context.SaveChanges();

            var sportklasses = new List<Sportklasse>{
                new Sportklasse { naam="Niveau 1", indeling= KlassenIndeling.Junioren, SportID = sporten.Single(s => s.naam == "Voetbal").ID},
                new Sportklasse { naam="Niveau 2", indeling= KlassenIndeling.Junioren, SportID=sporten.Single(s => s.naam == "Voetbal").ID},
                new Sportklasse { naam="Niveau 3", indeling= KlassenIndeling.Junioren, SportID=sporten.Single(s => s.naam == "Voetbal").ID},
                new Sportklasse { naam="Niveau 4", indeling= KlassenIndeling.Junioren, SportID=sporten.Single(s => s.naam == "Voetbal").ID},
                new Sportklasse { naam="Niveau 1", indeling= KlassenIndeling.Kinderen, SportID=sporten.Single(s => s.naam == "Voetbal").ID},
                new Sportklasse { naam="Niveau 2", indeling= KlassenIndeling.Kinderen, SportID=sporten.Single(s => s.naam == "Voetbal").ID},
                new Sportklasse { naam="Niveau 3", indeling= KlassenIndeling.Kinderen, SportID=sporten.Single(s => s.naam == "Voetbal").ID},
                new Sportklasse { naam="Niveau 4", indeling= KlassenIndeling.Kinderen, SportID=sporten.Single(s => s.naam == "Voetbal").ID},
                new Sportklasse { naam="Niveau 1", indeling= KlassenIndeling.Senioren, SportID=sporten.Single(s => s.naam == "Voetbal").ID},
                new Sportklasse { naam="Niveau 2", indeling= KlassenIndeling.Senioren, SportID=sporten.Single(s => s.naam == "Voetbal").ID},
                new Sportklasse { naam="Niveau 3", indeling= KlassenIndeling.Senioren, SportID=sporten.Single(s => s.naam == "Voetbal").ID},
                new Sportklasse { naam="Niveau 4", indeling= KlassenIndeling.Senioren, SportID=sporten.Single(s => s.naam == "Voetbal").ID},
                new Sportklasse { naam="Niveau 1", indeling= KlassenIndeling.Junioren, SportID=sporten.Single(s => s.naam == "Handbal").ID},
                new Sportklasse { naam="Niveau 2", indeling= KlassenIndeling.Junioren, SportID=sporten.Single(s => s.naam == "Handbal").ID},
                new Sportklasse { naam="Niveau 3", indeling= KlassenIndeling.Junioren, SportID=sporten.Single(s => s.naam == "Handbal").ID},
                new Sportklasse { naam="Niveau 1", indeling= KlassenIndeling.Kinderen, SportID=sporten.Single(s => s.naam == "Handbal").ID},
                new Sportklasse { naam="Niveau 2", indeling= KlassenIndeling.Kinderen, SportID=sporten.Single(s => s.naam == "Handbal").ID},
                new Sportklasse { naam="Niveau 3", indeling= KlassenIndeling.Kinderen, SportID=sporten.Single(s => s.naam == "Handbal").ID},
                new Sportklasse { naam="Niveau 1", indeling= KlassenIndeling.Senioren, SportID=sporten.Single(s => s.naam == "Handbal").ID},
                new Sportklasse { naam="Niveau 2", indeling= KlassenIndeling.Senioren, SportID=sporten.Single(s => s.naam == "Handbal").ID},
                new Sportklasse { naam="Niveau 3", indeling= KlassenIndeling.Senioren, SportID=sporten.Single(s => s.naam == "Handbal").ID},
                new Sportklasse { naam="Niveau 1", indeling= KlassenIndeling.Junioren, SportID=sporten.Single(s => s.naam == "Korfbal").ID},
                new Sportklasse { naam="Niveau 2", indeling= KlassenIndeling.Junioren, SportID=sporten.Single(s => s.naam == "Korfbal").ID},
                new Sportklasse { naam="Niveau 3", indeling= KlassenIndeling.Junioren, SportID=sporten.Single(s => s.naam == "Korfbal").ID},
                new Sportklasse { naam="Niveau 1", indeling= KlassenIndeling.Kinderen, SportID=sporten.Single(s => s.naam == "Korfbal").ID},
                new Sportklasse { naam="Niveau 2", indeling= KlassenIndeling.Kinderen, SportID=sporten.Single(s => s.naam == "Korfbal").ID},
                new Sportklasse { naam="Niveau 3", indeling= KlassenIndeling.Kinderen, SportID=sporten.Single(s => s.naam == "Korfbal").ID},
                new Sportklasse { naam="Niveau 1", indeling= KlassenIndeling.Senioren, SportID=sporten.Single(s => s.naam == "Korfbal").ID},
                new Sportklasse { naam="Niveau 2", indeling= KlassenIndeling.Senioren, SportID=sporten.Single(s => s.naam == "Korfbal").ID},
                new Sportklasse { naam="Niveau 3", indeling= KlassenIndeling.Senioren, SportID=sporten.Single(s => s.naam == "Korfbal").ID},
                new Sportklasse { naam="Niveau 1", indeling= KlassenIndeling.Junioren, SportID=sporten.Single(s => s.naam == "Tourfietsen").ID},
                new Sportklasse { naam="Niveau 2", indeling= KlassenIndeling.Junioren, SportID=sporten.Single(s => s.naam == "Tourfietsen").ID},
                new Sportklasse { naam="Niveau 1", indeling= KlassenIndeling.Kinderen, SportID=sporten.Single(s => s.naam == "Tourfietsen").ID},
                new Sportklasse { naam="Niveau 2", indeling= KlassenIndeling.Kinderen, SportID=sporten.Single(s => s.naam == "Tourfietsen").ID},
                new Sportklasse { naam="Niveau 1", indeling= KlassenIndeling.Senioren, SportID=sporten.Single(s => s.naam == "Tourfietsen").ID},
                new Sportklasse { naam="Niveau 2", indeling= KlassenIndeling.Senioren, SportID=sporten.Single(s => s.naam == "Tourfietsen").ID},
                new Sportklasse { naam="Niveau 50Plus", indeling= KlassenIndeling.VijftigPlus, SportID=sporten.Single(s => s.naam == "Tourfietsen").ID},
                new Sportklasse { naam="Niveau 1", indeling= KlassenIndeling.Junioren, SportID=sporten.Single(s => s.naam == "Crossfietsen").ID},
                new Sportklasse { naam="Niveau 1", indeling= KlassenIndeling.Kinderen, SportID=sporten.Single(s => s.naam == "Crossfietsen").ID},
                new Sportklasse { naam="Niveau 1", indeling= KlassenIndeling.Senioren, SportID=sporten.Single(s => s.naam == "Crossfietsen").ID},
                new Sportklasse { naam="Niveau 1", indeling= KlassenIndeling.Junioren, SportID=sporten.Single(s => s.naam == "Wielrenners").ID},
                new Sportklasse { naam="Niveau 2", indeling= KlassenIndeling.Junioren, SportID=sporten.Single(s => s.naam == "Wielrenners").ID},
                new Sportklasse { naam="Niveau 1", indeling= KlassenIndeling.Kinderen, SportID=sporten.Single(s => s.naam == "Wielrenners").ID},
                new Sportklasse { naam="Niveau 2", indeling= KlassenIndeling.Kinderen, SportID=sporten.Single(s => s.naam == "Wielrenners").ID},
                new Sportklasse { naam="Niveau 1", indeling= KlassenIndeling.Senioren, SportID=sporten.Single(s => s.naam == "Wielrenners").ID},
                new Sportklasse { naam="Niveau 2", indeling= KlassenIndeling.Senioren, SportID=sporten.Single(s => s.naam == "Wielrenners").ID}
            };

            sportklasses.ForEach(s => context.klasses.AddOrUpdate(k => k.ID, s));
            context.SaveChanges();

            var betalingtypes = new List<BetalingType>{
                new BetalingType { Bedrag= 180, BetalingTypeNaam= "Niveau 1 Junioren Voetbal", SportklasseID= 1 },
                new BetalingType { Bedrag= 180, BetalingTypeNaam= "Niveau 2 Junioren Voetbal", SportklasseID= 2},
                new BetalingType { Bedrag= 180, BetalingTypeNaam= "Niveau 3 Junioren Voetbal", SportklasseID= 3},
                new BetalingType { Bedrag= 180, BetalingTypeNaam= "Niveau 4 Junioren Voetbal", SportklasseID= 4},
                new BetalingType { Bedrag= 150, BetalingTypeNaam= "Niveau 1 Kinderen Voetbal", SportklasseID= 5},
                new BetalingType { Bedrag= 150, BetalingTypeNaam= "Niveau 2 Kinderen Voetbal", SportklasseID= 6},
                new BetalingType { Bedrag= 150, BetalingTypeNaam= "Niveau 3 Kinderen Voetbal", SportklasseID= 7},
                new BetalingType { Bedrag= 150, BetalingTypeNaam= "Niveau 4 Kinderen Voetbal", SportklasseID= 8},
                new BetalingType { Bedrag= 300, BetalingTypeNaam= "Niveau 1 Senioren Voetbal", SportklasseID= 9},
                new BetalingType { Bedrag= 250, BetalingTypeNaam= "Niveau 2 Senioren Voetbal", SportklasseID= 10},
                new BetalingType { Bedrag= 225, BetalingTypeNaam= "Niveau 3 Senioren Voetbal", SportklasseID= 11},
                new BetalingType { Bedrag= 210, BetalingTypeNaam= "Niveau 4 Senioren Voetbal", SportklasseID= 12},
                new BetalingType { Bedrag= 165, BetalingTypeNaam= "Niveau 1 Junioren Handbal", SportklasseID= 13},
                new BetalingType { Bedrag= 165, BetalingTypeNaam= "Niveau 2 Junioren Handbal", SportklasseID= 14},
                new BetalingType { Bedrag= 165, BetalingTypeNaam= "Niveau 3 Junioren Handbal", SportklasseID= 15},
                new BetalingType { Bedrag= 140, BetalingTypeNaam= "Niveau 1 Kinderen Handbal", SportklasseID= 16},
                new BetalingType { Bedrag= 140, BetalingTypeNaam= "Niveau 2 Kinderen Handbal", SportklasseID= 17},
                new BetalingType { Bedrag= 140, BetalingTypeNaam= "Niveau 3 Kinderen Handbal", SportklasseID= 18},
                new BetalingType { Bedrag= 250, BetalingTypeNaam= "Niveau 1 Senioren Handbal", SportklasseID= 19},
                new BetalingType { Bedrag= 210, BetalingTypeNaam= "Niveau 2 Senioren Handbal", SportklasseID= 20},
                new BetalingType { Bedrag= 200, BetalingTypeNaam= "Niveau 3 Senioren Handbal", SportklasseID= 21},
                new BetalingType { Bedrag= 165, BetalingTypeNaam= "Niveau 1 Junioren Korfbal", SportklasseID= 22},
                new BetalingType { Bedrag= 165, BetalingTypeNaam= "Niveau 2 Junioren Korfbal", SportklasseID= 23},
                new BetalingType { Bedrag= 165, BetalingTypeNaam= "Niveau 3 Junioren Korfbal", SportklasseID= 24},
                new BetalingType { Bedrag= 140, BetalingTypeNaam= "Niveau 1 Kinderen Korfbal", SportklasseID= 25},
                new BetalingType { Bedrag= 140, BetalingTypeNaam= "Niveau 2 Kinderen Korfbal", SportklasseID= 26},
                new BetalingType { Bedrag= 140, BetalingTypeNaam= "Niveau 3 Kinderen Korfbal", SportklasseID= 27},
                new BetalingType { Bedrag= 250, BetalingTypeNaam= "Niveau 1 Senioren Korfbal", SportklasseID= 28},
                new BetalingType { Bedrag= 210, BetalingTypeNaam= "Niveau 2 Senioren Korfbal", SportklasseID= 29},
                new BetalingType { Bedrag= 200, BetalingTypeNaam= "Niveau 3 Senioren Korfbal", SportklasseID= 30},
                new BetalingType { Bedrag= 100, BetalingTypeNaam= "Niveau 1 Junioren Toerfietsen", SportklasseID= 31},
                new BetalingType { Bedrag= 100, BetalingTypeNaam= "Niveau 2 Junioren Toerfietsen", SportklasseID= 32},
                new BetalingType { Bedrag= 85, BetalingTypeNaam= "Niveau 1 Kinderen Toerfietsen", SportklasseID= 33},
                new BetalingType { Bedrag= 85, BetalingTypeNaam= "Niveau 2 Kinderen Toerfietsen", SportklasseID= 34},
                new BetalingType { Bedrag= 150, BetalingTypeNaam= "Niveau 1 Senioren Toerfietsen", SportklasseID= 35},
                new BetalingType { Bedrag= 135, BetalingTypeNaam= "Niveau 2 Senioren Toerfietsen", SportklasseID= 36},
                new BetalingType { Bedrag= 125, BetalingTypeNaam= "Niveau 50PLUS 50+ Toerfietsen", SportklasseID= 37},
                new BetalingType { Bedrag= 135, BetalingTypeNaam= "Niveau 1 Junioren Crossfietsen", SportklasseID= 38},
                new BetalingType { Bedrag= 100, BetalingTypeNaam= "Niveau 1 Kinderen Voetbal", SportklasseID= 39},
                new BetalingType { Bedrag= 190, BetalingTypeNaam= "Niveau 1 Senioren Voetbal", SportklasseID= 40},
                new BetalingType { Bedrag= 190, BetalingTypeNaam= "Niveau 1 Junioren Wielrenners", SportklasseID= 41},
                new BetalingType { Bedrag= 190, BetalingTypeNaam= "Niveau 2 Junioren Wielrenners", SportklasseID= 42},
                new BetalingType { Bedrag= 160, BetalingTypeNaam= "Niveau 1 Kinderen Wielrenners", SportklasseID= 43},
                new BetalingType { Bedrag= 160, BetalingTypeNaam= "Niveau 2 Kinderen Wielrenners", SportklasseID= 44},
                new BetalingType { Bedrag= 280, BetalingTypeNaam= "Niveau 1 Senioren Wielrenners", SportklasseID= 45},
                new BetalingType { Bedrag= 250, BetalingTypeNaam= "Niveau 2 Senioren Wielrenners", SportklasseID= 46}
            };

            betalingtypes.ForEach(s => context.BetalingTypes.AddOrUpdate(b => b.BetalingTypeNaam, s));
            context.SaveChanges();
        }
    }
}
