//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TP2.EF
{
    using System;
    using System.Collections.Generic;
    
    public partial class Codigo_Fatura
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Codigo_Fatura()
        {
            this.Fatura = new HashSet<Fatura>();
        }
    
        public decimal ano { get; set; }
        public decimal nr_fat { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Fatura> Fatura { get; set; }
    }
}
