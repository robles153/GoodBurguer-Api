using GoodBurguer.GoodBurguer.Domain.Entities;

namespace GoodBurguer.GoodBurguer.Application.Interfaces
{
    public interface IProdutoRepository
    {
        Task<Produto?> ObterPorIdAsync(Guid id);
        Task<IEnumerable<Produto>> ListarAsync();

        Task AdicionarAsync(Produto produto);
        void Atualizar(Produto produto);
    }
}
