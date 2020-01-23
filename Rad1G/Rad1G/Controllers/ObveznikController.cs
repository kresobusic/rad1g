using Rad1G.Domain;
using Rad1G.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Rad1G.Controllers
{
    [Authorize(Roles =("Administrator, Zaposlenik"))]
    public class ObveznikController : Controller
    {
        private Rad1GEntities dbContext = new Rad1GEntities();
        public ActionResult Index()
        {
            var obveznici = dbContext.Obvezniks.ToList();
            var obveznikViewModels = new List<ObveznikViewModel>();
            foreach(var v in obveznici)
            {
                var obveznik = new ObveznikViewModel() {
                    DodjeljeniZaposlenik = v.AspNetUser.FirstName + " " + v.AspNetUser.LastName,
                    Id = v.Id,
                    IdZaposlenika = v.IdZaposlenika,
                    OIB = v.OIB,
                    Kontakt = v.Kontakt,
                    Naziv = v.Naziv
                };
                obveznikViewModels.Add(obveznik);
            }
            return View(obveznikViewModels);
        }
        public ActionResult DodajObveznika()
        {
            var zaposlenici = dbContext.AspNetUsers.ToList();

            List<ZaposlenikViewModel> listaZaposlenika = new List<ZaposlenikViewModel>();
            foreach(var zaposlenik in zaposlenici)
            {
                var zap = new ZaposlenikViewModel();
                zap.Id = zaposlenik.Id;
                zap.Naziv = zaposlenik.FirstName + " " + zaposlenik.LastName;
                listaZaposlenika.Add(zap);
            }
            ViewBag.Zaposlenici = listaZaposlenika;

            return View();
        }

        [HttpPost]
        public ActionResult DodajObveznika(ObveznikViewModel obveznik)
        {
            var noviObveznik = new Obveznik();
            noviObveznik.Naziv = obveznik.Naziv;
            noviObveznik.Kontakt = obveznik.Kontakt;
            noviObveznik.OIB = obveznik.OIB;
            noviObveznik.IdZaposlenika = obveznik.IdZaposlenika;

            dbContext.Obvezniks.Add(noviObveznik);
            dbContext.SaveChanges();

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult UrediObveznika(int id)
        {
            var zaposlenici = dbContext.AspNetUsers.ToList();

            List<ZaposlenikViewModel> listaZaposlenika = new List<ZaposlenikViewModel>();
            foreach (var zaposlenik in zaposlenici)
            {
                var zap = new ZaposlenikViewModel();
                zap.Id = zaposlenik.Id;
                zap.Naziv = zaposlenik.FirstName + " " + zaposlenik.LastName;
                listaZaposlenika.Add(zap);
            }
            ViewBag.Zaposlenici = listaZaposlenika;
            var obveznik = dbContext.Obvezniks.FirstOrDefault(x => x.Id == id);
            var obveznikViewModel = new ObveznikViewModel()
            {
                IdZaposlenika = obveznik.IdZaposlenika,
                Id = obveznik.Id,
                OIB = obveznik.OIB,
                Naziv = obveznik.Naziv,
                Kontakt = obveznik.Kontakt
            };

            return View(obveznikViewModel);
        }

        [HttpPost]
        public ActionResult UrediObveznika(ObveznikViewModel model)
        {
            var obveznik = dbContext.Obvezniks.FirstOrDefault(x => x.Id == model.Id);
            obveznik.IdZaposlenika = model.IdZaposlenika;
            obveznik.Kontakt = model.Kontakt;
            obveznik.Naziv = model.Naziv;
            obveznik.OIB = model.OIB;

            dbContext.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}