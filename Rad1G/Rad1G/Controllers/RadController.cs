using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Rad1G.Domain;
using Rad1G.Models;

namespace Rad1G.Controllers
{
    [Authorize(Roles ="Administrator, Zaposlenik")]
    public class RadController : Controller
    {
        private Rad1GEntities dbContext = new Rad1GEntities();

        public ActionResult ObradeniObveznici()
        {      
            return View();
        }
        public ActionResult NeobradeniObveznici()
        {
            return View();
        }


        [HttpGet]
        public PartialViewResult _NeobradeniObveznici(string param = "")
        {
            var curentUserId = User.Identity.GetUserId();
            var korisnik = dbContext.AspNetUsers.SingleOrDefault(x => x.Id == curentUserId);

            var korisnikoviNeobradeniObveznici = korisnik.Obvezniks.Where(x => x.PodaciUneseni == null || x.PodaciUneseni == false).ToList();

            if(param != "")
            {
                korisnikoviNeobradeniObveznici = korisnikoviNeobradeniObveznici.Where(x => x.Naziv.Contains(param) || x.OIB.Contains(param) || x.Kontakt.Contains(param)).ToList();
            }

            List<ObveznikViewModel> obveznikNeobradenoViewModels = new List<ObveznikViewModel>();
            foreach (var v in korisnikoviNeobradeniObveznici)
            {
                var obveznik = new ObveznikViewModel()
                {
                    Id = v.Id,
                    Naziv = v.Naziv,
                    OIB = v.OIB,
                    Kontakt = v.Kontakt
                };
                obveznikNeobradenoViewModels.Add(obveznik);
            }

            return PartialView("_NeobradeniObveznici", obveznikNeobradenoViewModels);
        }
        [HttpGet]
        public PartialViewResult _ObradeniObveznici(string param = "")
        {
            var curentUserId = User.Identity.GetUserId();
            var korisnik = dbContext.AspNetUsers.SingleOrDefault(x => x.Id == curentUserId);

            var korisnikoviObradeniObveznici = korisnik.Obvezniks.Where(x => x.PodaciUneseni != null && x.PodaciUneseni == true).ToList();

            if (param != "")
            {
                korisnikoviObradeniObveznici = korisnikoviObradeniObveznici.Where(x => x.Naziv.Contains(param) || x.OIB.Contains(param) || x.Kontakt.Contains(param)).ToList();
            }

            List<ObveznikViewModel> obveznikObradenoViewModels = new List<ObveznikViewModel>();
            foreach (var v in korisnikoviObradeniObveznici)
            {
                var obveznik = new ObveznikViewModel()
                {
                    Id = v.Id,
                    Naziv = v.Naziv,
                    OIB = v.OIB,
                    Kontakt = v.Kontakt
                };
                obveznikObradenoViewModels.Add(obveznik);
            }
            return PartialView("_ObradeniObveznici", obveznikObradenoViewModels);
        }

        [HttpGet]
        public ActionResult UnosPodataka(int id)
        {
            PodaciViewModel podaciViewModel = new PodaciViewModel();
            podaciViewModel.ObveznikId=id;
            return View(podaciViewModel);
        }

        [HttpPost]
        public ActionResult UnosPodataka(PodaciViewModel podaciViewModel)
        {
            var newPodaci = new RadPodaci();
            newPodaci.ObveznikId = podaciViewModel.ObveznikId;
            newPodaci.ZaposlenikId = User.Identity.GetUserId();
            newPodaci.BrutoPlacaMuskarci = podaciViewModel.BrutoPlacaMuskarci;
            newPodaci.NetoPlacaMuskarci = podaciViewModel.NetoPlacaMuskarci;
            newPodaci.BrojZaposlenihMuskarci = podaciViewModel.BrojZaposlenihMuskarci;

            newPodaci.BrutoPlacaZene = podaciViewModel.BrutoPlacaZene;
            newPodaci.NetoPlacaZene = podaciViewModel.NetoPlacaZene;
            newPodaci.BrojZaposlenihZene = podaciViewModel.BrojZaposlenihZene;

            newPodaci.BrutoPlacaVisokaStrucnaSprema = podaciViewModel.BrutoPlacaVisokaStrucnaSprema;
            newPodaci.NetoPlacaVisokaStrucnaSprema = podaciViewModel.NetoPlacaVisokaStrucnaSprema;
            newPodaci.BrojZaposlenihVisokaStrucnaSprema = podaciViewModel.BrojZaposlenihVisokaStrucnaSprema;

            newPodaci.BrutoPlacaVisaStrucnaSprema = podaciViewModel.BrutoPlacaVisaStrucnaSprema;
            newPodaci.NetoPlacaVisaStrucnaSprema = podaciViewModel.NetoPlacaVisaStrucnaSprema;
            newPodaci.BrojZaposlenihVisaStrucnaSprema = podaciViewModel.BrojZaposlenihVisaStrucnaSprema;

            newPodaci.BrutoPlacaSrednjaStrucnaSprema = podaciViewModel.BrutoPlacaSrednjaStrucnaSprema;
            newPodaci.NetoPlacaSrednjaStrucnaSprema = podaciViewModel.NetoPlacaSrednjaStrucnaSprema;
            newPodaci.BrojZaposlenihSrednjaStrucnaSprema = podaciViewModel.BrojZaposlenihSrednjaStrucnaSprema;

            newPodaci.BrutoPlacaNizaStrucnaSprema = podaciViewModel.BrutoPlacaNizaStrucnaSprema;
            newPodaci.NetoPlacaNizaStrucnaSprema = podaciViewModel.NetoPlacaNizaStrucnaSprema;
            newPodaci.BrojZaposlenihNizaStrucnaSprema = podaciViewModel.BrojZaposlenihNizaStrucnaSprema;

            newPodaci.BrutoPlacaVisokokvalificirani = podaciViewModel.BrutoPlacaVisokokvalificirani;
            newPodaci.NetoPlacaVisokokvalificirani = podaciViewModel.NetoPlacaVisokokvalificirani;
            newPodaci.BrojZaposlenihVisokokvalificirani = podaciViewModel.BrojZaposlenihVisokokvalificirani;

            newPodaci.BrutoPlacaKvalificirani = podaciViewModel.BrutoPlacaKvalificirani;
            newPodaci.NetoPlacaKvalificirani = podaciViewModel.NetoPlacaKvalificirani;
            newPodaci.BrojZaposlenihKvalificirani = podaciViewModel.BrojZaposlenihKvalificirani;

            newPodaci.BrutoPlacaPriuceni = podaciViewModel.BrutoPlacaPriuceni;
            newPodaci.NetoPlacaPriuceni = podaciViewModel.NetoPlacaPriuceni;
            newPodaci.BrojZaposlenihPriuceni = podaciViewModel.BrojZaposlenihPriuceni;

            newPodaci.BrutoPlacaNekvalificirani = podaciViewModel.BrutoPlacaNekvalificirani;
            newPodaci.NetoPlacaNekvalificirani = podaciViewModel.NetoPlacaNekvalificirani;
            newPodaci.BrojZaposlenihNekvalificirani = podaciViewModel.BrojZaposlenihNekvalificirani;

            dbContext.RadPodacis.Add(newPodaci);

            var obveznik = dbContext.Obvezniks.SingleOrDefault(x => x.Id == podaciViewModel.ObveznikId);
            obveznik.PodaciUneseni = true;

            dbContext.SaveChanges();

            return RedirectToAction("NeobradeniObveznici");
        }
    }
}