using GoodBurguer.GoodBurguer.Application.Interfaces;
using GoodBurguer.GoodBurguer.Domain.Entities;
using GoodBurguer.GoodBurguer.Domain.Exceptions;
using MediatR;

namespace GoodBurguer.GoodBurguer.Application.Pedidos.DeletarPedido
{
    public class DeletarPedidoHandler : IRequestHandler<DeletarPedidoRequest, DeletarPedidoResponse>
    {
        private readonly IPedidoRepository _pedidoRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<DeletarPedidoHandler> _logger;

        public DeletarPedidoHandler(IPedidoRepository pedidoRepository, IUnitOfWork unitOfWork, ILogger<DeletarPedidoHandler> logger)
        {
            _pedidoRepository = pedidoRepository;
            _unitOfWork = unitOfWork;
            _logger = logger;
        }

        public async Task<DeletarPedidoResponse> Handle(DeletarPedidoRequest request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Deletando pedido: {PedidoId}", request.PedidoId);

            var pedido = await ObterPedido(request.PedidoId);

            _pedidoRepository.Remover(pedido);

            await _unitOfWork.CommitAsync();

            _logger.LogInformation("Pedido deletado com sucesso: {PedidoId}", request.PedidoId);

            return new DeletarPedidoResponse
            {
                PedidoId = pedido.Id,
                Sucesso = true
            };
        }

        private async Task<Pedido> ObterPedido(Guid pedidoId)
        {
            var pedido = await _pedidoRepository.ObterPorIdAsync(pedidoId);

            if (pedido == null)
            {
                _logger.LogWarning("Pedido não encontrado: {PedidoId}", pedidoId);
                throw new DomainException("Pedido não encontrado");
            }

            return pedido;
        }
    }
}
