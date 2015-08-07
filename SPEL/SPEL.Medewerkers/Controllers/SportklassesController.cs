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

namespace SPEL.Medewerkers.Controllers
{
    public class SportklassesController : Controller
    {
        private IRepository<Sportklasse> klasses;
        private IRepository<Sport> sporten;

        public SportklassesController(IRepository<Sportklasse> a_repo, IRepository<Sport> a_sporten){
            klasses = a_repo;
            sporten = a_sporten;
        }

        // GET: Sportklasses
        public ActionResult Index()
        {
            
            return View(klasses.List);
        }

        // GET: Sportklasses/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sportklasse sportklasse = klasses.FindById((int)id);
            if (sportklasse == null)
            {
                return HttpNotFound();
            }
            return View(sportklasse);
        }

        // GET: Sportklasses/Create
        public ActionResult Create()
        {
            ViewBag.SportID = new SelectList(sporten.List, "ID", "naam");
            return View();
        }

        // POST: Sportklasses/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,naam,minLeeftijd,maxLeeftijd,SportID")] Sportklasse sportklasse)
        {
            if (ModelState.IsValid)
            {
                klasses.Add(sportklasse);
                return RedirectToAction("Index");
            }

            ViewBag.SportID = new SelectList(sporten.List, "ID", "naam", sportklasse.SportID);
            return View(sportklasse);
        }

        // GET: Sportklasses/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sportklasse sportklasse = klasses.FindById((int)id);
            if (sportklasse == null)
            {
                return HttpNotFound();
            }
            ViewBag.SportID = new SelectList(sporten.List, "ID", "naam", sportklasse.SportID);
            return View(sportklasse);
        }

        // POST: Sportklasses/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,naam,minLeeftijd,maxLeeftijd,SportID")] Sportklasse sportklasse)
        {
            if (ModelState.IsValid)
            {
                klasses.Add(sportklasse);
                return RedirectToAction("Index");
            }
            ViewBag.SportID = new SelectList(sporten.List, "ID", "naam", sportklasse.SportID);
            return View(sportklasse);
        }

        // GET: Sportklasses/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sportklasse sportklasse = klasses.FindById((int)id);
            if (sportklasse == null)
            {
                return HttpNotFound();
            }
            return View(sportklasse);
        }

        // POST: Sportklasses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Sportklasse sportklasse = klasses.FindById(id);
            klasses.Delete(sportklasse);
            return RedirectToAction("Index");
        }

       
    }
}
