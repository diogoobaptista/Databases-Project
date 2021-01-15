using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace Services
{
    public class ProdutoService
    {
        private ProdutoMapper ppMapper = new ProdutoMapper();
        public List<Produto> GetProdutos()
        {
            return ppMapper.GetProdutos();
        }

    }
}
