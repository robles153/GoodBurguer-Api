using GoodBurguer.GoodBurguer.Domain.Entities;

namespace GoodBurguer.GoodBurguer.Application.Interfaces
{
    public interface IPedidoRepository
    {
        Task<Pedido?> ObterPorIdAsync(Guid id);
        Task AdicionarAsync(Pedido pedido);
    }
}
