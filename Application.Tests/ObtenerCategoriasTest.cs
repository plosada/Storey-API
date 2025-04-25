using Application.Interfaces;
using Application.ObtenerCategorias;
using Domain.Entities;
using FluentAssertions;
using Moq;
using System.Net;
using System.Reflection.Metadata;
using System.Threading;

namespace Tests.Application
{
    public class ObtenerCategoriasTest
    {
        private readonly Mock<ICategoriaRepository> categoriaRepository;

        private readonly ObtenerCategoriasQueryHandler _handler;

        private readonly List<Categoria> _categorias;

        private ObtenerCategoriasQuery _request = new ();

        private readonly CancellationToken _cancellationToken = CancellationToken.None;

        public ObtenerCategoriasTest()
        {
            categoriaRepository = new Mock<ICategoriaRepository>();

            _handler = new ObtenerCategoriasQueryHandler(categoriaRepository.Object);

            _categorias = new List<Categoria>
                    {
                        new Categoria
                        {
                            categoria = "Iluminacion",
                            Items = new List<Item>
                            {
                                new Item { Elemento = "Lámpara Led de 5w", Valor = 5 },
                                new Item { Elemento = "Lámpara Led de 10w", Valor = 10 },
                                new Item { Elemento = "Lámpara Incandescente 40w", Valor = 40 },
                                new Item { Elemento = "Lámpara Incandescente de 100w", Valor = 100 },
                                new Item { Elemento = "Lámpara Incandescente de 200w", Valor = 200 }
                            }
                        },
                        new Categoria
                        {
                            categoria = "Refrigeracion",
                            Items = new List<Item>
                            {
                                new Item { Elemento = "Heladera", Valor = 1000 },
                                new Item { Elemento = "Freezer", Valor = 1500 }
                            }
                        }
                    };
        }

        [Fact]
        public async Task Handle_ObtenerCategorias_OK()
        {
            // Se configura el Mock
            categoriaRepository.Setup(_ => _.GetAll()).ReturnsAsync(_categorias);

            // Act
            var result = await _handler.Handle(_request, _cancellationToken);

            // Assert
            result.Categorias.Count.Should().Be(2);
        }


        [Fact]
        public async Task Handle_BalanceNotExists()
        {
            // Se configura el Mock
            categoriaRepository.Setup(_ => _.GetAll()).ReturnsAsync((List<Categoria>)null);
            // Act
            var result = await _handler.Handle(_request, _cancellationToken);

            // Assert
            result.Categorias.Should().BeNull();
        }

        [Fact]
        public async Task Handle_GetBalanceByNumeroCuenta_ThrowException()
        {
            // Se configura el Mock
            categoriaRepository.Setup(_ => _.GetAll()).Throws(new Exception());

            // Act
            var result = await _handler.Handle(_request, _cancellationToken);

            // Assert
            result.Categorias.Should().BeNull();
        }

    }
}