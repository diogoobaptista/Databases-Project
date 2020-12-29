using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    class Codigo_Fatura
    {
        public decimal ano { get; set; }
        public decimal nr_fat { get; set; }
        public Fatura fatura { get; set; }
    }
}
