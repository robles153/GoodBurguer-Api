using GoodBurguer.GoodBurguer.API.Respostas;
using GoodBurguer.GoodBurguer.Application.Pedidos.CriarPedido;
using GoodBurguer.GoodBurguer.Application.Pedidos.ObterPedidoPorId;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GoodBurguer.GoodBurguer.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PedidoController : ControllerBase
    {
        private readonly IMediator _mediator;

        public PedidoController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Criar([FromBody] CriarPedidoRequest request)
        {
            var response = await _mediator.Send(request);
            return Ok(ApiResponse<CriarPedidoResponse>.Ok(response));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Obter(Guid id)
        {
            var response = await _mediator.Send(new ObterPedidoPorIdRequest(id));
            return Ok(ApiResponse<ObterPedidoPorIdResponse>.Ok(response));
        }
    }
}
