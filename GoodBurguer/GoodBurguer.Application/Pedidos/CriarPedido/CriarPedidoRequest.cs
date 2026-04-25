using MediatR;

namespace GoodBurguer.GoodBurguer.Application.Pedidos.CriarPedido
{
    public class CriarPedidoRequest : IRequest<CriarPedidoResponse>
    {
        public List<Guid> ProdutoIds { get; set; } = new();
    }
}
