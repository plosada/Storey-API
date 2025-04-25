using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;

namespace Application.ObtenerCategorias
{
    public class ObtenerCategoriasQueryResponse
    {
        public List<Categoria> Categorias { get; set; }
    }
}
