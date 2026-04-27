using GoodBurguer.GoodBurguer.Application.DTOs.ResponseDtos.Pedido;

namespace GoodBurguer.GoodBurguer.Application.Pedidos.ListarPedidos
{
    public class ListarPedidosResponse
    {
        public int Page { get; set; }
        public int PageSize { get; set; }
        public int TotalRegistros { get; set; }
        public List<PedidoItemDto> Dados { get; set; } = new();
    }
}
