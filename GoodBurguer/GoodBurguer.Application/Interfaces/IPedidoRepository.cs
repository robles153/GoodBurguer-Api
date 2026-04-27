using GoodBurguer.GoodBurguer.Domain.Entities;

namespace GoodBurguer.GoodBurguer.Application.Interfaces
{
    public interface IPedidoRepository
    {
        Task<Pedido?> ObterPorIdAsync(Guid id);
        Task AdicionarAsync(Pedido pedido);
        Task<(IEnumerable<Pedido> Pedidos, int Total)> ListarPaginadoAsync(int page, int pageSize);
        void Atualizar(Pedido pedido);
        void Remover(Pedido pedido);
    }
}
