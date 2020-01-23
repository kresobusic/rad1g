using Rad1G.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Rad1G.Controllers
{
    public class HomeController : Controller
    {
        private Rad1GEntities dbContext = new Rad1GEntities();
        public ActionResult Index()
        {
            var brojObveznika = dbContext.Obvezniks.Count();
            ViewBag.BrojObveznika = brojObveznika;
            var brojObveznikaObradeno = dbContext.Obvezniks.Where(x => x.PodaciUneseni == true).Count();
            ViewBag.BrojObrađenihObveznika = brojObveznikaObradeno;
            var postotakObveznikaObradeno = (brojObveznikaObradeno / brojObveznika) * 100;
            ViewBag.PostotakObrađenihObveznika = postotakObveznikaObradeno;

            var radPodaci = dbContext.RadPodacis.ToList();

            ViewBag.StatistikaZenski = DohvatiZeneStatistike(radPodaci);
            ViewBag.StatistikaMuski = DohvatiMuskeStatistike(radPodaci);

            var statistikaStr = new decimal[] { DohvatiVisokuStrucnuSpremuStatistike(radPodaci), DohvatiVisuStrucnuSpremuStatistike(radPodaci), DohvatiSrednjuStrucnuSpremuStatistike(radPodaci),
                DohvatiNizuStrucnuSpremuStatistike(radPodaci), DohvatiVisokokvalificiraneStatistike(radPodaci), DohvatiKvalificiraneStatistike(radPodaci), DohvatiPriuceneStatistike(radPodaci), DohvatiNekvalificiraneStatistike(radPodaci) };
            ViewBag.StatistikaStrucnaSprema = statistikaStr;
            return View();
        }

        private decimal DohvatiMuskeStatistike(List<RadPodaci> radPodaci)
        {
            var sumBrutoMuski = 0;
            var countBrojZaposlenihMuski = 0;

            foreach (var v in radPodaci.Where(x => x.BrutoPlacaMuskarci != null && x.BrutoPlacaMuskarci > 0))
            {
                sumBrutoMuski += v.BrutoPlacaMuskarci.Value * v.BrojZaposlenihMuskarci.Value;
                countBrojZaposlenihMuski += v.BrojZaposlenihMuskarci.Value;
            }

            return sumBrutoMuski / countBrojZaposlenihMuski;
        }

        private decimal DohvatiZeneStatistike(List<RadPodaci> radPodaci)
        {
            var sumBrutoZene = 0;
            var countBrojZaposlenihZene = 0;

            foreach (var v in radPodaci.Where(x => x.BrutoPlacaZene != null && x.BrutoPlacaZene > 0))
            {
                sumBrutoZene += v.BrutoPlacaZene.Value * v.BrojZaposlenihZene.Value;
                countBrojZaposlenihZene += v.BrojZaposlenihZene.Value;
            }

            return sumBrutoZene / countBrojZaposlenihZene;
        }

        private decimal DohvatiVisokuStrucnuSpremuStatistike(List<RadPodaci> radPodaci)
        {
            var sumBrutoVisokaStrucnaSprema = 0;
            var countBrojZaposlenihVisokaStrucnaSprema = 0;

            foreach (var v in radPodaci.Where(x => x.BrutoPlacaVisokaStrucnaSprema != null && x.BrutoPlacaVisokaStrucnaSprema > 0))
            {
                sumBrutoVisokaStrucnaSprema += v.BrutoPlacaVisokaStrucnaSprema.Value * v.BrojZaposlenihVisokaStrucnaSprema.Value;
                countBrojZaposlenihVisokaStrucnaSprema += v.BrojZaposlenihVisokaStrucnaSprema.Value;
            }

            return sumBrutoVisokaStrucnaSprema / countBrojZaposlenihVisokaStrucnaSprema;
        }

        private decimal DohvatiVisuStrucnuSpremuStatistike(List<RadPodaci> radPodaci)
        {
            var sumBrutoVisaStrucnaSprema = 0;
            var countBrojZaposlenihVisaStrucnaSprema = 0;

            foreach (var v in radPodaci.Where(x => x.BrutoPlacaVisaStrucnaSprema != null && x.BrutoPlacaVisaStrucnaSprema > 0))
            {
                sumBrutoVisaStrucnaSprema += v.BrutoPlacaVisaStrucnaSprema.Value * v.BrojZaposlenihVisaStrucnaSprema.Value;
                countBrojZaposlenihVisaStrucnaSprema += v.BrojZaposlenihVisaStrucnaSprema.Value;
            }

            return sumBrutoVisaStrucnaSprema / countBrojZaposlenihVisaStrucnaSprema;
        }

        private decimal DohvatiSrednjuStrucnuSpremuStatistike(List<RadPodaci> radPodaci)
        {
            var sumBrutoSrednjaStrucnaSprema = 0;
            var countBrojZaposlenihSrednjaStrucnaSprema = 0;

            foreach (var v in radPodaci.Where(x => x.BrutoPlacaSrednjaStrucnaSprema != null && x.BrutoPlacaSrednjaStrucnaSprema > 0))
            {
                sumBrutoSrednjaStrucnaSprema += v.BrutoPlacaSrednjaStrucnaSprema.Value * v.BrojZaposlenihSrednjaStrucnaSprema.Value;
                countBrojZaposlenihSrednjaStrucnaSprema += v.BrojZaposlenihSrednjaStrucnaSprema.Value;
            }

            return sumBrutoSrednjaStrucnaSprema / countBrojZaposlenihSrednjaStrucnaSprema;
        }

        private decimal DohvatiNizuStrucnuSpremuStatistike(List<RadPodaci> radPodaci)
        {
            var sumBrutoNizaStrucnaSprema = 0;
            var countBrojZaposlenihNizaStrucnaSprema = 0;

            foreach (var v in radPodaci.Where(x => x.BrutoPlacaNizaStrucnaSprema != null && x.BrutoPlacaNizaStrucnaSprema > 0))
            {
                sumBrutoNizaStrucnaSprema += v.BrutoPlacaNizaStrucnaSprema.Value * v.BrojZaposlenihNizaStrucnaSprema.Value;
                countBrojZaposlenihNizaStrucnaSprema += v.BrojZaposlenihNizaStrucnaSprema.Value;
            }

            return sumBrutoNizaStrucnaSprema / countBrojZaposlenihNizaStrucnaSprema;
        }

        private decimal DohvatiVisokokvalificiraneStatistike(List<RadPodaci> radPodaci)
        {
            var sumBrutoVisokokvalificirani = 0;
            var countBrojZaposlenihVisokokvalificirani = 0;

            foreach (var v in radPodaci.Where(x => x.BrutoPlacaVisokokvalificirani != null && x.BrutoPlacaVisokokvalificirani > 0))
            {
                sumBrutoVisokokvalificirani += v.BrutoPlacaVisokokvalificirani.Value * v.BrojZaposlenihVisokokvalificirani.Value;
                countBrojZaposlenihVisokokvalificirani += v.BrojZaposlenihVisokokvalificirani.Value;
            }

            return sumBrutoVisokokvalificirani / countBrojZaposlenihVisokokvalificirani;
        }

        private decimal DohvatiKvalificiraneStatistike(List<RadPodaci> radPodaci)
        {
            var sumBrutoKvalificirani = 0;
            var countBrojZaposlenihKvalificirani = 0;

            foreach (var v in radPodaci.Where(x => x.BrutoPlacaKvalificirani != null && x.BrutoPlacaKvalificirani > 0))
            {
                sumBrutoKvalificirani += v.BrutoPlacaKvalificirani.Value * v.BrojZaposlenihKvalificirani.Value;
                countBrojZaposlenihKvalificirani += v.BrojZaposlenihKvalificirani.Value;
            }

            return sumBrutoKvalificirani / countBrojZaposlenihKvalificirani;
        }

        private decimal DohvatiPriuceneStatistike(List<RadPodaci> radPodaci)
        {
            var sumBrutoPriuceni = 0;
            var countBrojZaposlenihPriuceni = 0;

            foreach (var v in radPodaci.Where(x => x.BrutoPlacaPriuceni != null && x.BrutoPlacaPriuceni > 0))
            {
                sumBrutoPriuceni += v.BrutoPlacaPriuceni.Value * v.BrojZaposlenihPriuceni.Value;
                countBrojZaposlenihPriuceni += v.BrojZaposlenihPriuceni.Value;
            }

            return sumBrutoPriuceni / countBrojZaposlenihPriuceni;
        }

        private decimal DohvatiNekvalificiraneStatistike(List<RadPodaci> radPodaci)
        {
            var sumBrutoNekvalificirani = 0;
            var countBrojZaposlenihNekvalificirani = 0;

            foreach (var v in radPodaci.Where(x => x.BrutoPlacaNekvalificirani != null && x.BrutoPlacaNekvalificirani > 0))
            {
                sumBrutoNekvalificirani += v.BrutoPlacaNekvalificirani.Value * v.BrojZaposlenihNekvalificirani.Value;
                countBrojZaposlenihNekvalificirani += v.BrojZaposlenihNekvalificirani.Value;
            }

            return sumBrutoNekvalificirani / countBrojZaposlenihNekvalificirani;
        }
    }
}