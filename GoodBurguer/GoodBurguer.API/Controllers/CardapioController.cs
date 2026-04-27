using GoodBurguer.GoodBurguer.API.Respostas;
using GoodBurguer.GoodBurguer.Application.Cardapio.ListarCardapio;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace GoodBurguer.GoodBurguer.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CardapioController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CardapioController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("cardapio")]
        public async Task<IActionResult> ListarCardapio()
        {
            var response = await _mediator.Send(new ListarCardapioRequest());

            return Ok(ApiResponse<ListarCardapioResponse>.Ok(response));
        }
    }
}
