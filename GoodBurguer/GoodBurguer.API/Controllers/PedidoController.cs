using GoodBurguer.GoodBurguer.API.Respostas;
using GoodBurguer.GoodBurguer.Application.DTOs.RequestDtos.Pedido;
using GoodBurguer.GoodBurguer.Application.Pedidos.AtualizarPedido;
using GoodBurguer.GoodBurguer.Application.Pedidos.CriarPedido;
using GoodBurguer.GoodBurguer.Application.Pedidos.DeletarPedido;
using GoodBurguer.GoodBurguer.Application.Pedidos.ListarPedidos;
using GoodBurguer.GoodBurguer.Application.Pedidos.ObterPedidoPorId;
using MediatR;
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

        [HttpPost("criar-pedido")]
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

        [HttpGet("listar-pedidos")]
        public async Task<IActionResult> Listar([FromQuery] int page = 1, [FromQuery] int pageSize = 10)
        {
            var request = new ListarPedidosRequest(page, pageSize);

            var response = await _mediator.Send(request);

            return Ok(ApiResponse<ListarPedidosResponse>.Ok(response));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Atualizar(Guid id, [FromBody] AtualizarPedidoDto dto)
        {
            var request = new AtualizarPedidoRequest(id, dto.ProdutoIds);

            var response = await _mediator.Send(request);

            return Ok(ApiResponse<AtualizarPedidoResponse>.Ok(response));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Deletar(Guid id)
        {
            var response = await _mediator.Send(new DeletarPedidoRequest(id));

            return Ok(ApiResponse<DeletarPedidoResponse>.Ok(response));
        }
    }
}
