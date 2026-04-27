namespace GoodBurguer.GoodBurguer.Application.DTOs.RequestDtos.Pedido
{
    public class AtualizarPedidoDto
    {
        public List<Guid> ProdutoIds { get; set; } = new();
    }
}
