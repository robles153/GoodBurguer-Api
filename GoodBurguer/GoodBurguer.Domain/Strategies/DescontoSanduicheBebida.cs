using GoodBurguer.GoodBurguer.Domain.Entities;
using GoodBurguer.GoodBurguer.Domain.Enums;

namespace GoodBurguer.GoodBurguer.Domain.Strategies
{
    public class DescontoSanduicheBebida : IDescontoStrategy
    {
        public bool EhAplicavel(IReadOnlyCollection<ItemPedido> itens)
        {
            return Tem(TipoItem.Sanduiche, itens) &&
                   Tem(TipoItem.Bebida, itens);
        }

        public decimal CalcularDesconto(IReadOnlyCollection<ItemPedido> itens)
        {
            var total = itens.Sum(i => i.Preco);
            return total * 0.15m;
        }

        private bool Tem(TipoItem tipo, IReadOnlyCollection<ItemPedido> itens)
        {
            return itens.Any(i => i.Tipo == tipo);
        }
    }
}
