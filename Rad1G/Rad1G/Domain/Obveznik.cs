//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Rad1G.Domain
{
    using System;
    using System.Collections.Generic;
    
    public partial class Obveznik
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Obveznik()
        {
            this.RadPodacis = new HashSet<RadPodaci>();
        }
    
        public int Id { get; set; }
        public string Naziv { get; set; }
        public string OIB { get; set; }
        public string Kontakt { get; set; }
        public string IdZaposlenika { get; set; }
        public Nullable<bool> PodaciUneseni { get; set; }
    
        public virtual AspNetUser AspNetUser { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RadPodaci> RadPodacis { get; set; }
    }
}
