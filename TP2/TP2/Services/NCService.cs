using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace Services
{
    public class NCService
    {
        private NCMapper NcMapper = new NCMapper();
        public List<Nota_Cred> GetNotasCred()
        {
            return NcMapper.GetNotasCred();
        }

    }
}

