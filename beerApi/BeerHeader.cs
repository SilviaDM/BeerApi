//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace beerApi
{
    using System;
    using System.Collections.Generic;
    
    public partial class BeerHeader
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public BeerHeader()
        {
            this.BeerVariety = new HashSet<BeerVariety>();
        }
    
        public int IdBeer { get; set; }
        public string Brand { get; set; }
        public string Description { get; set; }
        public int IdCountry { get; set; }
        public int IdStatus { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BeerVariety> BeerVariety { get; set; }
    }
}