using GoodBurguer.GoodBurguer.Application.DTOs.ResponseDtos.Pedido;

namespace GoodBurguer.GoodBurguer.Application.Pedidos.ObterPedidoPorId
{
    public class ObterPedidoPorIdResponse 
    {
        public PedidoDetalheDto Pedido { get; set; } = default!;
    }    
}
