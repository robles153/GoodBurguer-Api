using GoodBurguer.GoodBurguer.Domain.Entities;

namespace GoodBurguer.GoodBurguer.Domain.Strategies
{
    public interface IDescontoStrategy
    {
        bool EhAplicavel(IReadOnlyCollection<ItemPedido> itens);
        decimal CalcularDesconto(IReadOnlyCollection<ItemPedido> itens);
    }
}
