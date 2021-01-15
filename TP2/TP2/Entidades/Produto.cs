using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Produto
    {
        public string sku { get; set; }
        public string desc_prod { get; set; }
        public int perc_iva { get; set; }
        public decimal preco_unit { get; set; }
        public List<Item> itens { get; set; }
    }
}
