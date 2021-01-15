using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace Services
{
    public class AddItemService
    {
        private AddItemMapper itemMapper = new AddItemMapper();
        public List<Item> GetItemsFat()
        {
            return itemMapper.GetItemsFat();
        }

    }
}
