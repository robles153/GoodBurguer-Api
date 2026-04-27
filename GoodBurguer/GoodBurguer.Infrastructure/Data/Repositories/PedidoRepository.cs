using GoodBurguer.GoodBurguer.Application.Interfaces;
using GoodBurguer.GoodBurguer.Domain.Entities;
using GoodBurguer.GoodBurguer.Infrastructure.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace GoodBurguer.GoodBurguer.Infrastructure.Data.Repositories
{
    public class PedidoRepository : IPedidoRepository
    {
        private readonly AppDbContext _context;

        public PedidoRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Pedido?> ObterPorIdAsync(Guid id)
        {
            return await _context.Pedidos
                .Include(p => p.Itens)
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task AdicionarAsync(Pedido pedido)
        {
            await _context.Pedidos.AddAsync(pedido);
        }

        public async Task<(IEnumerable<Pedido>, int)> ListarPaginadoAsync(int page, int pageSize)
        {
            var query = _context.Pedidos
                .Include(p => p.Itens)
                .AsQueryable();

            var total = await query.CountAsync();

            var pedidos = await query
                .OrderByDescending(p => p.Id)
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            return (pedidos, total);
        }

        public void Atualizar(Pedido pedido)
        {
            var itensAntigos = _context.ItensPedido
                .Where(i => i.PedidoId == pedido.Id)
                .ToList();

            _context.ItensPedido.RemoveRange(itensAntigos);

            foreach (var item in pedido.Itens)
            {                
                _context.Entry(item).State = EntityState.Added;
            }

            _context.Pedidos.Update(pedido);
        }

        public void Remover(Pedido pedido)
        {
            _context.Pedidos.Remove(pedido);
        }
    }
}

