namespace GoodBurguer.GoodBurguer.Application.DTOs.ResponseDtos.Pedido
{
    public class PedidoDetalheDto
    {
        public Guid PedidoId { get; set; }
        public decimal Subtotal { get; set; }
        public decimal Desconto { get; set; }
        public decimal Total { get; set; }

        public List<ItemPedidoDto> Itens { get; set; } = new();
    }

    public class ItemPedidoDto
    {
        public string Nome { get; set; }
        public decimal Preco { get; set; }
        public string Tipo { get; set; }
    }
}
