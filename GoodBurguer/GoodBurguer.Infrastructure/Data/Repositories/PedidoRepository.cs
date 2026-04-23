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
    }
}

