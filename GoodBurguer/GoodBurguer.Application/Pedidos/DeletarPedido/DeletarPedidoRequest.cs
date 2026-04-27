using MediatR;

namespace GoodBurguer.GoodBurguer.Application.Pedidos.DeletarPedido
{
    public class DeletarPedidoRequest : IRequest<DeletarPedidoResponse>
    {
        public Guid PedidoId { get; set; }

        public DeletarPedidoRequest(Guid pedidoId)
        {
            PedidoId = pedidoId;
        }
    }
}
