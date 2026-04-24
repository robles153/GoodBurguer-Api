using GoodBurguer.GoodBurguer.Domain.Entities;
using GoodBurguer.GoodBurguer.Domain.Enums;

namespace GoodBurguer.GoodBurguer.Domain.Strategies
{
    public class DescontoSanduicheAcompanhamento : IDescontoStrategy
    {
        public bool EhAplicavel(Pedido pedido)
        {
            var itens = pedido.Itens;

            return Tem(TipoItem.Sanduiche, itens) &&
                   Tem(TipoItem.Acompanhamento, itens) &&
                   !Tem(TipoItem.Bebida, itens);
        }

        public decimal CalcularDesconto(Pedido pedido)
        {
            return pedido.Itens.Sum(i => i.Preco) * 0.10m;
        }

        private bool Tem(TipoItem tipo, IReadOnlyCollection<ItemPedido> itens)
        {
            return itens.Any(i => i.Tipo == tipo);
        }
    }
}
