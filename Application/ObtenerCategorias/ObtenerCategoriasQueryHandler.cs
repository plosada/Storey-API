using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Interfaces;
using MediatR;

namespace Application.ObtenerCategorias
{
    public class ObtenerCategoriasQueryHandler : IRequestHandler<ObtenerCategoriasQuery, ObtenerCategoriasQueryResponse>
    {
        private readonly ICategoriaRepository _categoriaRepository;

        public ObtenerCategoriasQueryHandler(ICategoriaRepository categoriaRepository)
        {
            _categoriaRepository = categoriaRepository;
        }

        public async Task<ObtenerCategoriasQueryResponse> Handle(ObtenerCategoriasQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var categorias = await _categoriaRepository.GetAll();

                if (categorias == null)
                {
                    return new ObtenerCategoriasQueryResponse { };
                }

                return new ObtenerCategoriasQueryResponse
                {
                    Categorias = categorias
                };
            }
            catch (Exception ex)
            {
                return new ObtenerCategoriasQueryResponse { };
            }
        }
    }
}
