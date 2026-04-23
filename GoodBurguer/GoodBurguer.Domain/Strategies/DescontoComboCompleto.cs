using GoodBurguer.GoodBurguer.Domain.Entities;
using GoodBurguer.GoodBurguer.Domain.Enums;

namespace GoodBurguer.GoodBurguer.Domain.Strategies
{
    public class DescontoComboCompleto : IDescontoStrategy
    {
        public bool EhAplicavel(IReadOnlyCollection<ItemPedido> itens)
        {
            return Tem(TipoItem.Sanduiche, itens) &&
                   Tem(TipoItem.Bebida, itens) &&
                   Tem(TipoItem.Acompanhamento, itens);
        }

        public decimal CalcularDesconto(IReadOnlyCollection<ItemPedido> itens)
        {
            var total = itens.Sum(i => i.Preco);
            return total * 0.20m;
        }

        private bool Tem(TipoItem tipo, IReadOnlyCollection<ItemPedido> itens)
        {
            return itens.Any(i => i.Tipo == tipo);
        }
    }
}
