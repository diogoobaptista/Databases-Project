using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    class Contribuinte
    {
        public decimal nif { get; set; }
        public string nome { get; set; }
        public string morada { get; set; }
        public List<Fatura> faturas { get; set; }
    }
}
