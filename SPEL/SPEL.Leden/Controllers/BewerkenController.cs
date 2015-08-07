using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SPEL.Leden.Models;
using SPEL.Domain.Entities;
using SPEL.Domain.Abstract;
using Microsoft.AspNet.Identity;
using System.Net;



namespace SPEL.Leden.Controllers
{
    public class BewerkenController : Controller
    {

        private IRepository<Lid> Leden;
        private IEnumerable<Lid> lid;
        private IRepository<Lid> repository;

        public BewerkenController(IRepository<Lid> leden_repository, IRepository<Lid> repository)
        {
            Leden = leden_repository;
            this.repository = repository;


        }
        [Authorize]
        [HttpGet]
        // GET: Bewerken
        public ActionResult Bewerken()
        {
            Lid lid = null;
            LoginViewModellen gebruiker = new LoginViewModellen();
            gebruiker = new LoginViewModellen
            {

                leden = (from v in Leden.List where v.Email.Equals(User.Identity.GetUserName()) select v)

            };

            if (gebruiker.leden.First() == null)
            {

            }
            else
            {
                lid = gebruiker.leden.First();
            }
            return View(lid);
        }

        [Authorize]
        [HttpPost]
        public ActionResult Bewerken(Lid lid, HttpPostedFileBase image = null)
        {
            if (ModelState.IsValid)
            {
                if (image != null)
                {
                    lid.ImageMimeType = image.ContentType;
                    lid.ImageData = new byte[image.ContentLength];
                    image.InputStream.Read(lid.ImageData, 0, image.ContentLength);
                }
                Leden.Update(lid);
                return RedirectToAction("Bewerkt", lid);
            }
            return View();
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
    }
}