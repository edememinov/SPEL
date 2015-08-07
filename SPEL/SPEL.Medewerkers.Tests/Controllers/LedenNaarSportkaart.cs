using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SPEL.Medewerkers.Models;
using SPEL.Domain.Entities;
using SPEL.Medewerkers.Controllers;
using System.Collections;
using SPEL.Domain.Abstract;


namespace SPEL.Medewerkers.Tests.Content
{
    /// <summary>
    /// Summary description for LedenNaarSportkaart/
    /// </summary>
    [TestClass]
    public class LedenNaarSportkaart
    {
        Mock<IRepository<Lid>> a_mock = new Mock<IRepository<Lid>>();
        

        private List<Lid> leden = new List<Lid>{
                                  new Lid{ ID = 1 , Naam = "Henk Molengraaf", Geslacht = Geslacht.man, GebDatum = DateTime.Parse("12-07-2001"), Woonplaats = "Hoeven", Email = "Hansvroon@hansie.nl", Adres = "achter 6"},
                                  new Lid{ ID = 2 , Naam = "Kees Molengraaf", Geslacht = Geslacht.man, GebDatum = DateTime.Parse("12-07-2008"), Woonplaats = "Hoeven", Email = "Hansvroon1@hansie.nl", Adres = "achter 6"},
                                  new Lid{ ID = 3 , Naam = "Jan Molengraaf", Geslacht = Geslacht.man, GebDatum = DateTime.Parse("12-07-2007"), Woonplaats = "Hoeven", Email = "Hansvroon2@hansie.nl", Adres = "achter 6"},
                                  new Lid{ ID = 4 , Naam = "Henk Vis", Geslacht = Geslacht.man, GebDatum = DateTime.Parse("12-07-2005"), Woonplaats = "Breda", Email = "Kerel2@hansie.nl", Adres = "achter 7"},
                                  new Lid{ ID = 5 , Naam = "Jan Vis", Geslacht = Geslacht.man, GebDatum = DateTime.Parse("12-07-2008"), Woonplaats = "Breda", Email = "Kerel3@hansie.nl", Adres = "achter 7"},
                                  new Lid{ ID = 6 , Naam = "Karel Vis", Geslacht = Geslacht.man, GebDatum = DateTime.Parse("12-07-2004"), Woonplaats = "Breda", Email = "Kerel4@hansie.nl", Adres = "achter 7"},
                                  new Lid{ ID = 7 , Naam = "Tjebbe Kerstens", Geslacht = Geslacht.man, GebDatum = DateTime.Parse("12-07-2003"), Woonplaats = "Oosterhout", Email = "Dame1@hansie.nl", Adres = "achter 9"},
                                  new Lid{ ID = 8 , Naam = "Katrien Kersens", Geslacht = Geslacht.vrouw, GebDatum = DateTime.Parse("12-07-2002"), Woonplaats = "Oosterhout", Email = "Dame2@hansie.nl", Adres = "achter 9"}

                              }; 

        private List<Sport> sporten = new List<Sport>{
                                        new Sport { naam = "Voetbal", typeSport= TypeSport.Balsport},
                                        new Sport { naam = "Handbal", typeSport= TypeSport.Balsport},
                                        new Sport { naam = "Korfbal", typeSport= TypeSport.Balsport},
                                        new Sport { naam = "Tourfietsen", typeSport= TypeSport.Fietssport},
                                        new Sport { naam = "Crossfietsen", typeSport= TypeSport.Fietssport},
                                        new Sport { naam = "Wielrenners", typeSport= TypeSport.Fietssport}
                                  };

        private Sportklasse[] klasses = {
                new Sportklasse { naam="Niveau 1", indeling= KlassenIndeling.Junioren, SportID=1},
                new Sportklasse { naam="Niveau 2", indeling= KlassenIndeling.Junioren, SportID=1},
                new Sportklasse { naam="Niveau 3", indeling= KlassenIndeling.Junioren, SportID=1},
                new Sportklasse { naam="Niveau 4", indeling= KlassenIndeling.Junioren, SportID=1},
                new Sportklasse { naam="Niveau 1", indeling= KlassenIndeling.Kinderen, SportID=1},
                new Sportklasse { naam="Niveau 2", indeling= KlassenIndeling.Kinderen, SportID=1},
                new Sportklasse { naam="Niveau 3", indeling= KlassenIndeling.Kinderen, SportID=1},
                new Sportklasse { naam="Niveau 4", indeling= KlassenIndeling.Kinderen, SportID=1},
                new Sportklasse { naam="Niveau 1", indeling= KlassenIndeling.Senioren, SportID=1},
                new Sportklasse { naam="Niveau 2", indeling= KlassenIndeling.Senioren, SportID=1},
                new Sportklasse { naam="Niveau 3", indeling= KlassenIndeling.Senioren, SportID=1},
                new Sportklasse { naam="Niveau 4", indeling= KlassenIndeling.Senioren, SportID=1},
                new Sportklasse { naam="Niveau 1", indeling= KlassenIndeling.Junioren, SportID=2},
                new Sportklasse { naam="Niveau 2", indeling= KlassenIndeling.Junioren, SportID=2},
                new Sportklasse { naam="Niveau 3", indeling= KlassenIndeling.Junioren, SportID=2},
                new Sportklasse { naam="Niveau 1", indeling= KlassenIndeling.Kinderen, SportID=2},
                new Sportklasse { naam="Niveau 2", indeling= KlassenIndeling.Kinderen, SportID=2},
                new Sportklasse { naam="Niveau 3", indeling= KlassenIndeling.Kinderen, SportID=2},
                new Sportklasse { naam="Niveau 1", indeling= KlassenIndeling.Senioren, SportID=2},
                new Sportklasse { naam="Niveau 2", indeling= KlassenIndeling.Senioren, SportID=2},
                new Sportklasse { naam="Niveau 3", indeling= KlassenIndeling.Senioren, SportID=2},
                new Sportklasse { naam="Niveau 1", indeling= KlassenIndeling.Junioren, SportID=3},
                new Sportklasse { naam="Niveau 2", indeling= KlassenIndeling.Junioren, SportID=3},
                new Sportklasse { naam="Niveau 3", indeling= KlassenIndeling.Junioren, SportID=3},
                new Sportklasse { naam="Niveau 1", indeling= KlassenIndeling.Kinderen, SportID=3},
                new Sportklasse { naam="Niveau 2", indeling= KlassenIndeling.Kinderen, SportID=3},
                new Sportklasse { naam="Niveau 3", indeling= KlassenIndeling.Kinderen, SportID=3},
                new Sportklasse { naam="Niveau 1", indeling= KlassenIndeling.Senioren, SportID=3},
                new Sportklasse { naam="Niveau 2", indeling= KlassenIndeling.Senioren, SportID=3},
                new Sportklasse { naam="Niveau 3", indeling= KlassenIndeling.Senioren, SportID=3},
                new Sportklasse { naam="Niveau 1", indeling= KlassenIndeling.Junioren, SportID=4},
                new Sportklasse { naam="Niveau 2", indeling= KlassenIndeling.Junioren, SportID=4},
                new Sportklasse { naam="Niveau 1", indeling= KlassenIndeling.Kinderen, SportID=4},
                new Sportklasse { naam="Niveau 2", indeling= KlassenIndeling.Kinderen, SportID=4},
                new Sportklasse { naam="Niveau 1", indeling= KlassenIndeling.Senioren, SportID=4},
                new Sportklasse { naam="Niveau 2", indeling= KlassenIndeling.Senioren, SportID=4},
                new Sportklasse { naam="Niveau 50Plus", indeling= KlassenIndeling.VijftigPlus, SportID=4},
                new Sportklasse { naam="Niveau 1", indeling= KlassenIndeling.Junioren, SportID=5},
                new Sportklasse { naam="Niveau 1", indeling= KlassenIndeling.Kinderen, SportID=5},
                new Sportklasse { naam="Niveau 1", indeling= KlassenIndeling.Senioren, SportID=5},
                new Sportklasse { naam="Niveau 1", indeling= KlassenIndeling.Junioren, SportID=6},
                new Sportklasse { naam="Niveau 2", indeling= KlassenIndeling.Junioren, SportID=6},
                new Sportklasse { naam="Niveau 1", indeling= KlassenIndeling.Kinderen, SportID=6},
                new Sportklasse { naam="Niveau 2", indeling= KlassenIndeling.Kinderen, SportID=6},
                new Sportklasse { naam="Niveau 1", indeling= KlassenIndeling.Senioren, SportID=6},
                new Sportklasse { naam="Niveau 2", indeling= KlassenIndeling.Senioren, SportID=6}
                                        };

        private Inschrijving[] inschrijvingen = {
                                                    new Inschrijving { ID = 1, sportklasseId = 1, lidId = 1, datumInschrijving = DateTime.Parse("12-02-2015"), datumUitschrijving = DateTime.Parse("12-04-2015")},
                                                    new Inschrijving { ID = 2, sportklasseId = 2, lidId = 2, datumInschrijving = DateTime.Today, datumUitschrijving = null},
                                                    new Inschrijving { ID = 3, sportklasseId = 3, lidId = 2, datumInschrijving = DateTime.Today, datumUitschrijving = null},
                                                    new Inschrijving { ID = 4, sportklasseId = 4, lidId = 3, datumInschrijving = DateTime.Parse("12-02-2015"), datumUitschrijving = DateTime.Parse("12-05-2015")},
                                                    new Inschrijving { ID = 5, sportklasseId = 5, lidId = 1, datumInschrijving = DateTime.Parse("12-02-2015"), datumUitschrijving = null},
                                                };

        

        

        [TestMethod]
        public void TestJuisteLid()
        {
            // Arrange
            Mock<IRepository<Lid>> l_mock = new Mock<IRepository<Lid>>();
            l_mock.Setup(m => m.List).Returns(leden);

            Mock<IRepository<Inschrijving>> in_mock = new Mock<IRepository<Inschrijving>>();
            in_mock.Setup(m => m.List).Returns(inschrijvingen);

            Mock<IRepository<Sport>> s_mock = new Mock<IRepository<Sport>>();
            s_mock.Setup(m => m.List).Returns(sporten);

            Mock<IRepository<Sportklasse>> sk_mock = new Mock<IRepository<Sportklasse>>();
            sk_mock.Setup(m => m.List).Returns(klasses);

            LedenController controller = new LedenController(l_mock.Object, in_mock.Object, s_mock.Object, sk_mock.Object);

            // Act
            PrintenViewModel result = (PrintenViewModel)controller.getByIdPrint(2);

            // Assert
            Lid a_lid = result.leden[0];
            Assert.AreEqual(a_lid.Naam, "Kees Molengraaf");

        }

        [TestMethod]
        public void TestAlleLeden()
        {
            // Arrange
            Mock<IRepository<Lid>> l_mock = new Mock<IRepository<Lid>>();
            l_mock.Setup(m => m.List).Returns(leden);

            Mock<IRepository<Inschrijving>> in_mock = new Mock<IRepository<Inschrijving>>();
            in_mock.Setup(m => m.List).Returns(inschrijvingen);

            Mock<IRepository<Sport>> s_mock = new Mock<IRepository<Sport>>();
            s_mock.Setup(m => m.List).Returns(sporten);

            Mock<IRepository<Sportklasse>> sk_mock = new Mock<IRepository<Sportklasse>>();
            sk_mock.Setup(m => m.List).Returns(klasses);

            LedenController controller = new LedenController(l_mock.Object, in_mock.Object, s_mock.Object, sk_mock.Object);

            // Act
            PrintenViewModel result = (PrintenViewModel)controller.getAllePrint();
            
            

            // Assert
            
            Assert.AreEqual(result.leden.Count, 0) ;

        }
    }
}
