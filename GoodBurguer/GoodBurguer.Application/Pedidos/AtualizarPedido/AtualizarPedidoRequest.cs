using MediatR;

namespace GoodBurguer.GoodBurguer.Application.Pedidos.AtualizarPedido
{
    public class AtualizarPedidoRequest : IRequest<AtualizarPedidoResponse>
    {
        public Guid PedidoId { get; }
        public List<Guid> ProdutoIds { get; }

        public AtualizarPedidoRequest(Guid pedidoId, List<Guid> produtoIds)
        {
            PedidoId = pedidoId;
            ProdutoIds = produtoIds;
        }
    }
}
