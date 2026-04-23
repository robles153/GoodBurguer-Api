using GoodBurguer.GoodBurguer.Domain.Entities;

namespace GoodBurguer.GoodBurguer.Domain.Strategies
{
    public class SemDescontoStrategy : IDescontoStrategy
    {
        public bool EhAplicavel(IReadOnlyCollection<ItemPedido> itens)
        {
            return true;
        }

        public decimal CalcularDesconto(IReadOnlyCollection<ItemPedido> itens)
        {
            return 0;
        }
    }
}
