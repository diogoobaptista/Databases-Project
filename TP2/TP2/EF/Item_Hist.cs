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
    
    public partial class Item_Hist
    {
        public Nullable<int> num_item { get; set; }
        public string desc_item { get; set; }
        public Nullable<decimal> desconto { get; set; }
        public decimal num_uni { get; set; }
        public string codigo_fat { get; set; }
        public string sku { get; set; }
    
        public virtual Fatura Fatura { get; set; }
    }
}