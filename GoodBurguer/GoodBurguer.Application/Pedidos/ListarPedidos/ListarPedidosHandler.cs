using GoodBurguer.GoodBurguer.Application.DTOs.ResponseDtos.Pedido;
using GoodBurguer.GoodBurguer.Application.Interfaces;
using MediatR;

namespace GoodBurguer.GoodBurguer.Application.Pedidos.ListarPedidos
{
    public class ListarPedidosHandler : IRequestHandler<ListarPedidosRequest, ListarPedidosResponse>
    {
        private readonly IPedidoRepository _pedidoRepository;
        private readonly ILogger<ListarPedidosHandler> _logger;

        public ListarPedidosHandler(IPedidoRepository pedidoRepository, ILogger<ListarPedidosHandler> logger)
        {
            _pedidoRepository = pedidoRepository;
            _logger = logger;
        }

        public async Task<ListarPedidosResponse> Handle(ListarPedidosRequest request, CancellationToken cancellationToken)
        {
            _logger.LogInformation(
                "Listando pedidos - Page: {Page}, PageSize: {PageSize}",
                request.Page, request.PageSize);

            var (pedidos, total) = await _pedidoRepository
                .ListarPaginadoAsync(request.Page, request.PageSize);

            var dados = pedidos.Select(p => new PedidoItemDto
            {
                PedidoId = p.Id,
                Subtotal = p.Subtotal.Valor,
                Desconto = p.Desconto.Valor,
                Total = p.Total.Valor
            }).ToList();

            _logger.LogInformation(
                "Pedidos listados com sucesso. Quantidade retornada: {Quantidade}",
                dados.Count);

            return new ListarPedidosResponse
            {
                Page = request.Page,
                PageSize = request.PageSize,
                TotalRegistros = total,
                Dados = dados
            };
        }
    }
}
