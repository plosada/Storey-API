using Domain.Entities;
using Infrastructure;
using System;

namespace Practica_API
{
    public class DatabaseInitilaizer
    {
        public static void Seed(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<ApplicationDbContext>();

                if (!context.Categorias.Any())
                {
                    var categorias = new List<Categoria>
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

                    context.Categorias.AddRange(categorias);
                    context.SaveChanges();
                }
            }
        }
    }
}
