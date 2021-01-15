using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Nota_Cred
    {
        public string codigo_nc { get; set; }
        public decimal ano { get; set; }
        public decimal nr_nc { get; set; }
        public string dt_emissao { get; set; }
        public string dt_criacao { get; set; }
        public decimal val_nc { get; set; }
        public string estado { get; set; }
        public string codigo_fat { get; set; }
        public Nota_Cred notaCredito { get; set; }
        public List<Item_NC> itens { get; set; }
    }
}
