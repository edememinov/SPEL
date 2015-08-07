using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SPEL.Domain.Concrete;
using SPEL.Domain.Entities;
using SPEL.Domain.Abstract;
using SPEL.Medewerkers.Models;

namespace SPEL.Medewerkers.Controllers
{
    public class InschrijvingsController : Controller
    { 
        private IRepository<Inschrijving> inschrijvingen;
        private IRepository<Lid> leden;
        private IRepository<Sportklasse> klasses;
        private IRepository<BetalingType> betalingTypes;
        private IRepository<Betaling> betalingen;
        private Betaling betaling;
        private BetalingType betalingType;

        public InschrijvingsController(IRepository<Inschrijving> a_repo, IRepository<Lid> b_repo, IRepository<Sportklasse> c_repo, IRepository<Betaling> d_repo, IRepository<BetalingType> e_repo )
        {
            inschrijvingen = a_repo;
            leden = b_repo;
            klasses = c_repo;
            betalingTypes = e_repo;
            betalingen = d_repo;
        }

        // GET: inschrijvings
        public ActionResult Index()
        {
            return View(inschrijvingen.List);
        }

        public ActionResult PerPeriode()
        {
           
            return View();
        }

        // Post methode van PerPeriode
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult PerPeriode(PerPeriodeViewModel model)
        {
            if (model.beginDatum == null || model.eindDatum == null || model.inuit == null)
            {
                return HttpNotFound();
            }
            else {
                
                if (model.inuit)
                {
                    model.inschrijvingen = from i in inschrijvingen.List where i.datumUitschrijving <= model.eindDatum && i.datumUitschrijving >= model.beginDatum select i;
                }
                else
                {
                    model.inschrijvingen = from i in inschrijvingen.List where i.datumInschrijving >= model.beginDatum && i.datumInschrijving <= model.eindDatum select i;
                }
                return View(model);
            }
            
        }

        // GET: inschrijvings/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Inschrijving inschrijving = inschrijvingen.FindById((int)id);
            if (inschrijving == null)
            {
                return HttpNotFound();
            }
            return View(inschrijving);
        }

        // GET: inschrijvings/Create
        public ActionResult Create()
        {
            var list = inschrijvingen.GetAll();
            ViewBag.lidId = new SelectList(leden.List, "ID", "naam");
            ViewBag.sportklasseId = new SelectList(klasses.List, "ID", "naam");
            return View();
        }

        // POST: inschrijvings/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Inschrijving inschrijving)
        {
            if (ModelState.IsValid)
            {

                betalingType = betalingTypes.List.Where(x => x.SportklasseID == inschrijving.sportklasseId).First();
                betaling = new Betaling { Betaald = false, LidID = inschrijving.lidId, BetalingTypeID=betalingType.ID, Bedrag=betalingType.Bedrag};
                betalingen.Add(betaling);
                
                inschrijvingen.Add(inschrijving);
                
                return RedirectToAction("Index");
            }

            return View(inschrijving);
        }

        public ActionResult InschrijvingCreate()
        {
            ViewBag.leden = leden.List;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult InschrijvingCreate(InschrijvingViewModel model)
        {
            ViewBag.leden = leden.List;
            model.lid.GebDatum = leden.List.Where(l => l.ID == model.lid.ID).First().GebDatum;
            var leeftijdLid = (DateTime.Today - model.lid.GebDatum).Days/365;
            var mogelijkeKlasses = klasses.List.Where(k => k.minLeeftijd <= leeftijdLid && k.maxLeeftijd >= leeftijdLid);
            model.klasses = mogelijkeKlasses.ToList();
            return View(model);
        }

        public ActionResult SchrijfIn(int? id, int? lid)
        {
            if (id == null || lid == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Inschrijving inschrijving = new Inschrijving { lidId = (int)lid, sportklasseId = (int)id, datumInschrijving = DateTime.Today};
            inschrijvingen.Add(inschrijving);

            betalingType = betalingTypes.List.Where(x => x.SportklasseID == inschrijving.sportklasseId).First();
            betaling = new Betaling { Betaald = false, LidID = inschrijving.lidId, BetalingTypeID = betalingType.ID, Bedrag = betalingType.Bedrag };
            betalingen.Add(betaling);


            return RedirectToAction("Index");

        }

        // GET: inschrijvings/Edit/5
        public ActionResult Edit(int? id)
        {
            ViewBag.lidId = new SelectList(leden.List, "ID", "naam");
            ViewBag.sportklasseId = new SelectList(klasses.List, "ID", "naam");

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Inschrijving inschrijving = inschrijvingen.FindById((int)id);
            if (inschrijving == null)
            {
                return HttpNotFound();
            }
            return View(inschrijving);
        }

        // POST: inschrijvings/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Inschrijving inschrijving)
        {
            


            if (ModelState.IsValid)
            {
                inschrijvingen.Update(inschrijving);
                return RedirectToAction("Index");
            }
            return View(inschrijving);
        }

        // GET: inschrijvings/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Inschrijving inschrijving = inschrijvingen.FindById((int)id);
            
            if (inschrijving == null)
            {
                return HttpNotFound();
            }
            return View(inschrijving);
        }

        // POST: inschrijvings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            inschrijvingen.Delete(inschrijvingen.FindById((int)id));
            return RedirectToAction("Index");
        }
    }


        
}
