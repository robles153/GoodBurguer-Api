using GoodBurguer.GoodBurguer.Application.Interfaces;
using GoodBurguer.GoodBurguer.Domain.Entities;
using GoodBurguer.GoodBurguer.Infrastructure.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace GoodBurguer.GoodBurguer.Infrastructure.Data.Repositories
{
    public class ProdutoRepository : IProdutoRepository
    {
        private readonly AppDbContext _context;

        public ProdutoRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Produto?> ObterPorIdAsync(Guid id)
        {
            return await _context.Produtos
                .FirstOrDefaultAsync(p => p.Id == id && p.Ativo);
        }

        public async Task<IEnumerable<Produto>> ListarAsync()
        {
            return await _context.Produtos
                .Where(p => p.Ativo)
                .ToListAsync();
        }

        public async Task AdicionarAsync(Produto produto)
        {
            await _context.Produtos.AddAsync(produto);
        }

        public void Atualizar(Produto produto)
        {
            _context.Produtos.Update(produto);
        }

        public async Task<IEnumerable<Produto>> ObterPorIdsAsync(IEnumerable<Guid> ids)
        {
            return await _context.Produtos
                .Where(p => ids.Contains(p.Id) && p.Ativo)
                .ToListAsync();
        }
    }
}
