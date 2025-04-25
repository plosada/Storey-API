using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models
{
    public class CategoriaDTO
    {
        public string categoria { get; set; }
        public List<ItemDTO> items { get; set; }
    }

    public class ItemDTO
    {
        public string elemento { get; set; }
        public int valor { get; set; }
    }
}
