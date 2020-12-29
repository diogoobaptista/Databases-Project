using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    class Fatura
    {
        public string codigo_fat { get; set; }
        public decimal ano { get; set; }
        public decimal nr_fat { get; set; }
        public string dt_emissao { get; set; }
        public string dt_criacao { get; set; }
        public decimal val_total { get; set; }
        public int val_iva { get; set; }
        public string estado { get; set; }
        public decimal nif { get; set; }
        public Nota_Cred notaCredito { get; set; }
        public List <Item> itens { get; set; }
        public List<Fatura_Hist> faturasHistorico { get; set; }
        public List<Item_Hist> itensHistorico { get; set; }

    }
}
