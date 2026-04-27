using GoodBurguer.GoodBurguer.Application.DTOs.ResponseDtos.Pedido;
using GoodBurguer.GoodBurguer.Application.Pedidos.Compartilhado;

namespace GoodBurguer.GoodBurguer.Application.Pedidos.AtualizarPedido
{
    public class AtualizarPedidoResponse 
    {
        public PedidoItemDto Pedido { get; set; } = default!;
    }
}
