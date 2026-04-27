namespace GoodBurguer.GoodBurguer.Application.DTOs.ResponseDtos.Pedido
{
    public class PedidoItemDto
    {
        public Guid PedidoId { get; set; }
        public decimal Subtotal { get; set; }
        public decimal Desconto { get; set; }
        public decimal Total { get; set; }
    }
}
