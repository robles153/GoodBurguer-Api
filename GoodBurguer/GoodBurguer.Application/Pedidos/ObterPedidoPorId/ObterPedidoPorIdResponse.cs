using GoodBurguer.GoodBurguer.Application.Pedidos.Compartilhado;

namespace GoodBurguer.GoodBurguer.Application.Pedidos.ObterPedidoPorId
{
    public class ObterPedidoPorIdResponse : PedidoBaseResponse
    {
        public List<ItemPedidoResponse> Itens { get; set; } = new();
    }

    public class ItemPedidoResponse
    {
        public string Nome { get; set; }
        public decimal Preco { get; set; }
        public string Tipo { get; set; }
    }
}
