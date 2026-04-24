using GoodBurguer.GoodBurguer.Domain.Entities;
using GoodBurguer.GoodBurguer.Domain.Enums;

namespace GoodBurguer.GoodBurguer.Domain.Strategies
{
    public class DescontoComboCompleto : IDescontoStrategy
    {
        public bool EhAplicavel(Pedido pedido)
        {
            var itens = pedido.Itens;

            return Tem(TipoItem.Sanduiche, itens) &&
                   Tem(TipoItem.Bebida, itens) &&
                   Tem(TipoItem.Acompanhamento, itens);
        }

        public decimal CalcularDesconto(Pedido pedido)
        {
            return pedido.Itens.Sum(i => i.Preco) * 0.20m;
        }

        private bool Tem(TipoItem tipo, IReadOnlyCollection<ItemPedido> itens)
        {
            return itens.Any(i => i.Tipo == tipo);
        }
    }
}
