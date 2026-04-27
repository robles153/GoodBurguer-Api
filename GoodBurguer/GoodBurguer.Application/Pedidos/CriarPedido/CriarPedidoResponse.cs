using GoodBurguer.GoodBurguer.Application.DTOs.ResponseDtos.Pedido;
using GoodBurguer.GoodBurguer.Application.Pedidos.Compartilhado;

namespace GoodBurguer.GoodBurguer.Application.Pedidos.CriarPedido
{
    public class CriarPedidoResponse 
    {
        public PedidoItemDto Pedido { get; set; } = default!;
    }
}
