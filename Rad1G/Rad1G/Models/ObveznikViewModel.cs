using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Rad1G.Models
{
    public class ObveznikViewModel
    {
        public int Id { get; set; }
        public string Naziv { get; set; }
        public string OIB { get; set; }
        public string Kontakt { get; set; }
        public string IdZaposlenika { get; set; }
        [Display(Name ="Dodjeljen zaposleniku")]
        public string DodjeljeniZaposlenik { get; set; }
    }
}