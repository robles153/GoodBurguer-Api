using GoodBurguer.GoodBurguer.Domain.Entities;

namespace GoodBurguer.GoodBurguer.Domain.Strategies
{
    public interface IDescontoStrategy
    {
        bool EhAplicavel(Pedido pedido);
        decimal CalcularDesconto(Pedido pedido);
    }
}
