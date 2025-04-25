using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;
using Application.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class CategoriaRepository : ICategoriaRepository
    {
        protected readonly ApplicationDbContext _contexto;
        public CategoriaRepository(ApplicationDbContext contexto)
        {
            _contexto = contexto;
        }

        public async Task<List<Categoria>> GetAll()
        {
            var categorias = _contexto.Categorias.Include("Items").ToList();

            return categorias;
        }
    }
}
