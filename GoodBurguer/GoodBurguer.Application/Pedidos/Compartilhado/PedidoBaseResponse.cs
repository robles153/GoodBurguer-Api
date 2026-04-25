namespace GoodBurguer.GoodBurguer.Application.Pedidos.Compartilhado
{
    public abstract class PedidoBaseResponse
    {
        public Guid PedidoId { get; set; }
        public decimal Subtotal { get; set; }
        public decimal Desconto { get; set; }
        public decimal Total { get; set; }
    }
}
