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
    
    public partial class Codigo_NotaCred
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Codigo_NotaCred()
        {
            this.Nota_Cred = new HashSet<Nota_Cred>();
        }
    
        public decimal ano { get; set; }
        public decimal nr_nc { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Nota_Cred> Nota_Cred { get; set; }
    }
}
