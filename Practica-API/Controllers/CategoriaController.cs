using Application.ObtenerCategorias;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Practica_API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CategoriaController : ControllerBase
    {
        private readonly ILogger<CategoriaController> _logger;
        private readonly IMediator _mediator;

        public CategoriaController(ILogger<CategoriaController> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }

        [HttpGet("All")]
        public async Task<IActionResult> GetAll()
        {
            var response = await _mediator.Send(new ObtenerCategoriasQuery ());

            if (response == null)
            {
                return NotFound();
            }

            return Ok(response);
        }
    }
}
