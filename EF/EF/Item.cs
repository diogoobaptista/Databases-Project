//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace EF
{
    using System;
    using System.Collections.Generic;
    
    public partial class Item
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Item()
        {
            this.Item_NC = new HashSet<Item_NC>();
        }
    
        public int num_item { get; set; }
        public string desc_item { get; set; }
        public Nullable<decimal> desconto { get; set; }
        public decimal num_uni { get; set; }
        public string codigo_fat { get; set; }
        public string sku { get; set; }
    
        public virtual Fatura Fatura { get; set; }
        public virtual Produto Produto { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Item_NC> Item_NC { get; set; }
    }
}
