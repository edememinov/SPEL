using SPEL.Domain.Abstract;
using SPEL.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SPEL.Medewerkers.Models;


namespace SPEL.Medewerkers.Controllers
{
    public class BetalingController : Controller
    {
        private IRepository<Inschrijving> inschrijvingen;
        private IRepository<Lid> leden;
        private IRepository<Sportklasse> klasses;
        private IRepository<BetalingType> betalingTypes;
        private IRepository<Betaling> betalingen;
        private Betaling betaald;
        private BetalingType betalingType;

        public BetalingController(IRepository<Inschrijving> a_repo, IRepository<Lid> b_repo, IRepository<Sportklasse> c_repo, IRepository<Betaling> d_repo, IRepository<BetalingType> e_repo )
        {
            inschrijvingen = a_repo;
            leden = b_repo;
            klasses = c_repo;
            betalingTypes = e_repo;
            betalingen = d_repo;
        }

        // GET: Betaling
        [HttpGet]
        public ActionResult Index()
        {
            if (betalingen == null)
            {
                return View("GeenBetalingen");
            }
            else if (betalingen.List.Count() == 0)
            {
                return View("GeenBetalingen");
            }
            else 
            {
                return View(betalingen.List);
            }

            
        }
        [HttpPost]
        public ActionResult Index(Betaling betaling)
        {
            BetaalViewModel betalen = new BetaalViewModel();
            betalen = new BetaalViewModel
            {
                betaaldeRekeningen = (from v in betalingen.List where v.Betaald.Equals(betaling.Betaald) select v)
            };

            return View(betalen.betaaldeRekeningen);
        }

        public ActionResult Factuur()
        {

            var model = new PrintenViewModel();
            var alleBetalingen = betalingen.GetAll(b => b.Lid);
            alleBetalingen = alleBetalingen.Where(b => b.Betaald == false);
            var alleInschrijvingen = inschrijvingen.GetAll(v => v.sportklasse, v => v.lid);
            model.inschrijvingen = alleInschrijvingen.ToList();
            List<Lid> alleLeden = new List<Lid>();
            foreach (Betaling betaling in alleBetalingen)
            {
                if (alleLeden.Contains(betaling.Lid))
                {

                }
                else
                {
                    alleLeden.Add(betaling.Lid);
                }
            }
            model.leden = alleLeden;
            model.betaling = alleBetalingen.ToList();



            return new Rotativa.ViewAsPdf("Factuur", model) { FileName = "AlleFacturen.pdf" };

        }

        public ActionResult FactuurK()
        {
            var model = new PrintenViewModel();
            var alleBetalingen = betalingen.GetAll(b => b.Lid);
            alleBetalingen = alleBetalingen.Where(b => b.Betaald == false);
            var alleInschrijvingen = inschrijvingen.GetAll(v => v.sportklasse, v => v.lid);
            model.inschrijvingen = alleInschrijvingen.ToList();
            List<Lid> alleLeden = new List<Lid>();
            foreach (Betaling betaling in alleBetalingen)
            {
                if (alleLeden.Contains(betaling.Lid))
                {

                }
                else
                {
                    alleLeden.Add(betaling.Lid);
                }
            }
            model.leden = alleLeden;
            model.betaling = alleBetalingen.ToList();
            return new Rotativa.ViewAsPdf("FactuurK", model) { FileName = "AlleFacturenKwartaal.pdf" };

        }

        public ActionResult FactuurJ()
        {
            var model = new PrintenViewModel();
            var alleBetalingen = betalingen.GetAll(b => b.Lid);
            alleBetalingen = alleBetalingen.Where(b => b.Betaald == false);
            var alleInschrijvingen = inschrijvingen.GetAll(v => v.sportklasse, v => v.lid);
            model.inschrijvingen = alleInschrijvingen.ToList();
            List<Lid> alleLeden = new List<Lid>();
            foreach (Betaling betaling in alleBetalingen)
            {
                if (alleLeden.Contains(betaling.Lid))
                {

                }
                else
                {
                    alleLeden.Add(betaling.Lid);
                }
            }
            model.leden = alleLeden;
            model.betaling = alleBetalingen.ToList();
            return new Rotativa.ViewAsPdf("FactuurJ", model) { FileName = "AlleFacturenJaar.pdf" };

        }

        [ActionName("EenFactuur")]
        public ActionResult Factuur(int id)
        {
            var model = new PrintenViewModel();
            model.leden = new List<Lid>();
            model.leden.Add(leden.FindById(id));
            var inschrijvingenLid = inschrijvingen.GetAll(v => v.sportklasse, v => v.lid).Where(v => v.lidId == id);
            model.inschrijvingen = inschrijvingenLid.ToList();
            model.betaling = betalingen.List.ToList().Where(b => b.Betaald == false).ToList();



            return new Rotativa.ViewAsPdf("Factuur", model) { FileName = "Factuur.pfd" };


        }
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
    }
            Betaling betaling = betalingen.FindById((int)id);
            if (betaling == null)
            {
                return HttpNotFound();
            }
            return View(betaling);
        }

        public ActionResult Edit(int? id)
        {

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Betaling betaling = betalingen.FindById((int)id);
            if (betaling == null)
            {
                return HttpNotFound();
            }
            return View(betaling);
        }

        // POST: inschrijvings/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Betaling betaling)
        {



            if (ModelState.IsValid)
            {
                betalingen.Update(betaling);
                return RedirectToAction("Index");
            }
            return View(betaling);
        }
    }

}