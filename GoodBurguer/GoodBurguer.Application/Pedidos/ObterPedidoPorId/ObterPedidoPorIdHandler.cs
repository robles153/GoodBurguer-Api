using GoodBurguer.GoodBurguer.Application.Interfaces;
using GoodBurguer.GoodBurguer.Domain.Exceptions;
using MediatR;

namespace GoodBurguer.GoodBurguer.Application.Pedidos.ObterPedidoPorId
{
    public class ObterPedidoPorIdHandler : IRequestHandler<ObterPedidoPorIdRequest, ObterPedidoPorIdResponse>
    {
        private readonly IPedidoRepository _pedidoRepository;
        private readonly ILogger<ObterPedidoPorIdHandler> _logger;

        public ObterPedidoPorIdHandler(IPedidoRepository pedidoRepository, ILogger<ObterPedidoPorIdHandler> logger)
        {
            _pedidoRepository = pedidoRepository;
            _logger = logger;
        }

        public async Task<ObterPedidoPorIdResponse> Handle(ObterPedidoPorIdRequest request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Buscando pedido por Id: {PedidoId}", request.Id);

            var pedido = await _pedidoRepository.ObterPorIdAsync(request.Id);

            if (pedido == null)
            {
                _logger.LogWarning("Pedido não encontrado. Id: {PedidoId}", request.Id);
                throw new DomainException("Pedido não encontrado");
            }

            _logger.LogInformation("Pedido encontrado com sucesso. Id: {PedidoId}", pedido.Id);

            return new ObterPedidoPorIdResponse
            {
                PedidoId = pedido.Id,
                Subtotal = pedido.Subtotal.Valor,
                Desconto = pedido.Desconto.Valor,
                Total = pedido.Total.Valor,
                Itens = pedido.Itens.Select(i => new ItemPedidoResponse
                {
                    Nome = i.Nome,
                    Preco = i.Preco,
                    Tipo = i.Tipo.ToString()
                }).ToList()
            };
        }
    }
}
