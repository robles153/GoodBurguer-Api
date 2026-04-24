using GoodBurguer.GoodBurguer.Domain.Entities;

namespace GoodBurguer.GoodBurguer.Domain.Strategies
{
    public class SemDescontoStrategy : IDescontoStrategy
    {
        public bool EhAplicavel(Pedido pedido)
        {
            return true;
        }

        public decimal CalcularDesconto(Pedido pedido)
        {
            return 0;
        }
    }
}
