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
    
    public partial class Fatura_Hist
    {
        public string dt_atualizacao { get; set; }
        public string ultimo_estado { get; set; }
        public string dt_emissao { get; set; }
        public string dt_criacao { get; set; }
        public Nullable<decimal> val_total { get; set; }
        public Nullable<int> val_iva { get; set; }
        public string codigo_fat { get; set; }
        public Nullable<decimal> nif { get; set; }
    
        public virtual Contribuinte Contribuinte { get; set; }
        public virtual Fatura Fatura { get; set; }
    }
}
