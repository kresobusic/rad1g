using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Rad1G.Models
{
    public class PodaciViewModel
    {
        public int ObveznikId { get; set; }
        #region Spol
        public int BrutoPlacaMuskarci { get; set; }
        public int NetoPlacaMuskarci { get; set; }
        public int BrojZaposlenihMuskarci { get; set; }

        public int BrutoPlacaZene { get; set; }
        public int NetoPlacaZene { get; set; }
        public int BrojZaposlenihZene { get; set; }
        #endregion

        #region Strucna sprema
        public int BrutoPlacaVisokaStrucnaSprema { get; set; }
        public int NetoPlacaVisokaStrucnaSprema { get; set; }
        public int BrojZaposlenihVisokaStrucnaSprema { get; set; }

        public int BrutoPlacaVisaStrucnaSprema { get; set; }
        public int NetoPlacaVisaStrucnaSprema { get; set; }
        public int BrojZaposlenihVisaStrucnaSprema { get; set; }

        public int BrutoPlacaSrednjaStrucnaSprema { get; set; }
        public int NetoPlacaSrednjaStrucnaSprema { get; set; }
        public int BrojZaposlenihSrednjaStrucnaSprema { get; set; }

        public int BrutoPlacaNizaStrucnaSprema { get; set; }
        public int NetoPlacaNizaStrucnaSprema { get; set; }
        public int BrojZaposlenihNizaStrucnaSprema { get; set; }

        public int BrutoPlacaVisokokvalificirani { get; set; }
        public int NetoPlacaVisokokvalificirani { get; set; }
        public int BrojZaposlenihVisokokvalificirani { get; set; }

        public int BrutoPlacaKvalificirani { get; set; }
        public int NetoPlacaKvalificirani { get; set; }
        public int BrojZaposlenihKvalificirani { get; set; }

        public int BrutoPlacaPriuceni { get; set; }
        public int NetoPlacaPriuceni { get; set; }
        public int BrojZaposlenihPriuceni { get; set; }

        public int BrutoPlacaNekvalificirani { get; set; }
        public int NetoPlacaNekvalificirani { get; set; }
        public int BrojZaposlenihNekvalificirani { get; set; }
        #endregion

    }
}