using SPEL.Domain.Abstract;
using SPEL.Domain.Concrete;
using SPEL.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Rotativa;
using SPEL.Medewerkers.Models;

namespace SPEL.Medewerkers.Controllers
{
    public class LedenController : Controller
    {
        
        private IRepository<Lid> repository;
        private IRepository<Inschrijving> r_inschrijvingen;
        private IRepository<Sport> r_sporten;
        private IRepository<Sportklasse> r_klasses;
        private Lid bestaandlid;

        public LedenController(IRepository<Lid> repository, IRepository<Inschrijving> i_repo, IRepository<Sport> i_sporten, IRepository<Sportklasse> i_klasses)
        {
            this.repository = repository;
            this.r_inschrijvingen = i_repo;
            r_sporten = i_sporten;
            r_klasses = i_klasses;
        }

        [Authorize]
        // GET: Home
        [HttpGet]
        public ActionResult LidToevoegen()
        {
            return View();
        }
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LidToevoegen(Lid lid, HttpPostedFileBase image = null)
        {
          LidViewModel emailcheck = new LidViewModel();
          emailcheck = new LidViewModel
          {
            leden = repository.List.Where(x => x.Email.Equals(lid.Email))
          };

          if (emailcheck.leden.Count() == 0)
          {
              LidViewModel lidview = new LidViewModel();
              lidview = new LidViewModel
              {
                  leden = repository.List.Where(x => x.Naam.Equals(lid.Naam))
              };
              if (lidview.leden.Count() == 0)
              {
                  if (ModelState.IsValid)
                  {
                      if (image != null)
                      {
                          lid.ImageMimeType = image.ContentType;
                          lid.ImageData = new byte[image.ContentLength];
                          image.InputStream.Read(lid.ImageData, 0, image.ContentLength);
                      }
                      repository.Add(lid);
                      return View("Toegevoegd", lid);
                  }

                  return View(lid);
              }
              else
              {
                  return View("AlToegevoegd", lid);
              }
          }

          else
          {
              return View("EmailAdresBestaatAl", lid);
          }
            
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LidAlsnogtoevoegen(Lid lid, HttpPostedFileBase image = null)
        {

                if (ModelState.IsValid)
                {
                    if (image != null)
                    {
                        lid.ImageMimeType = image.ContentType;
                        lid.ImageData = new byte[image.ContentLength];
                        image.InputStream.Read(lid.ImageData, 0, image.ContentLength);
                    }
                    repository.Add(lid);
                    return View("Toegevoegd", lid);
                }

                return View(lid);
            

        }

        public ActionResult AlToegevoegd(Lid lid)
        {
            LidViewModel lidview = new LidViewModel();
            lidview = new LidViewModel
            {
                leden = repository.List.Where(x => x.ID == lid.ID)
            };
            bestaandlid = lidview.leden.First();
            return View(bestaandlid);
        }

        public FileContentResult GetImage(int ID)
        {
            Lid lid = repository.List.FirstOrDefault(p => p.ID == ID);
            if (lid.ImageMimeType != null)
            {
                return File(lid.ImageData, lid.ImageMimeType);
            }
            else
            {
                return null;
            }
        }

        public ActionResult LedenBeheer ()
        {

            return View(repository.List);
        }

        public ActionResult Sportkaart()
        {
            var model = getAllePrint();

            
            return new Rotativa.ViewAsPdf("Sportkaart", model) { FileName = "AlleSportkaarten.pdf" };
        }

        [ActionName("EenSportKaart")]
        public ActionResult Sportkaart(int id)
        {
            var model = getByIdPrint(id);

            return new Rotativa.ViewAsPdf("Sportkaart", model) { FileName = "sportkaart.pfd" };
        }

        public PrintenViewModel getByIdPrint(int id)
        {
            var model = new PrintenViewModel();
            model.leden = repository.List.Where(i => i.ID == id).ToList();
            model.inschrijvingen = (r_inschrijvingen.List.Where(k => k.lidId == id).ToList());
            model.klasses = r_klasses.List.ToList();
            return model;
        }

        public PrintenViewModel getAllePrint()
        {
            var model = new PrintenViewModel();
            var alleActieveInschrijvingen = r_inschrijvingen.GetAll(k => k.sportklasse, k => k.lid).Where(k => k.datumUitschrijving == null || k.datumUitschrijving > DateTime.Today);
            List<Lid> ledenActief = new List<Lid>();
            foreach(Inschrijving ins in alleActieveInschrijvingen){
                if (ledenActief.Contains(ins.lid))
                {

                }
                else
                {
                    ledenActief.Add(ins.lid);
                }
            }
            model.leden = ledenActief;
            model.inschrijvingen = alleActieveInschrijvingen.ToList();
            model.klasses = r_klasses.GetAll(k => k.sport).ToList();
            return model;
        }
    }
}