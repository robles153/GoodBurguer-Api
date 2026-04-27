using GoodBurguer.GoodBurguer.Application.DTOs.ResponseDtos.Pedido;
using GoodBurguer.GoodBurguer.Application.Pedidos.Compartilhado;

namespace GoodBurguer.GoodBurguer.Application.Pedidos.ObterPedidoPorId
{
    public class ObterPedidoPorIdResponse 
    {
        public PedidoDetalheDto Pedido { get; set; } = default!;
    }    
}
