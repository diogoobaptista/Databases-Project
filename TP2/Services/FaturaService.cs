using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;


namespace Services
{
    public class FaturaService
    {
        private FaturaMapper faturaMapper = new FaturaMapper();
        public List<Fatura> GetFatura()
        {
            return faturaMapper.GetFaturas();
        }

    }
}
