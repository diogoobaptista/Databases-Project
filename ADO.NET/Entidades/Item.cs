using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Item
    {
        public int num_item { get; set; }
        public string desc_item { get; set; }
        public decimal desconto { get; set; }
        public decimal num_uni { get; set; }
        public string codigo_fat { get; set; }
        public string sku { get; set; }
        public List<Item_NC> itens_nc { get; set; }
    }
}
