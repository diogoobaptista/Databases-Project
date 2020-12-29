using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    class Fatura_Hist
    {
        public string dt_atualizacao { get; set; }
        public string ultimo_estado { get; set; }
        public string dt_emissao { get; set; }
        public string dt_criacao { get; set; }
        public decimal val_total { get; set; }
        public int val_iva { get; set; }
        public string codigo_fat { get; set; }
        public decimal nif { get; set; }
    }
}
