using GoodBurguer.GoodBurguer.Domain.Abstractions;
using GoodBurguer.GoodBurguer.Domain.Enums;
using GoodBurguer.GoodBurguer.Domain.Exceptions;

namespace GoodBurguer.GoodBurguer.Domain.Entities
{
    public class Pedido : AggregateRoot
    {
        #region EF
        protected Pedido() { }
        #endregion

        private readonly List<ItemPedido> _itens = new();

        public IReadOnlyCollection<ItemPedido> Itens => _itens;

        public decimal Subtotal { get; private set; }
        public decimal Desconto { get; private set; }
        public decimal Total { get; private set; }

        public Pedido(IEnumerable<ItemPedido> itens)
        {
            Validar(itens);

            foreach (var item in itens)
            {
                _itens.Add(item);
            }
        }

        private void Validar(IEnumerable<ItemPedido> itens)
        {
            if (itens == null || !itens.Any())
                throw new DomainException("Pedido deve ter itens");

            if (ContarItensPorTipo(TipoItem.Sanduiche, itens) != 1)
                throw new DomainException("Pedido deve conter exatamente 1 sanduíche");

            if (ContarItensPorTipo(TipoItem.Bebida, itens) > 1)
                throw new DomainException("Pedido não pode conter mais de uma bebida");

            if (ContarItensPorTipo(TipoItem.Acompanhamento, itens) > 1)
                throw new DomainException("Pedido não pode conter mais de um acompanhamento");
        }

        private int ContarItensPorTipo(TipoItem tipo, IEnumerable<ItemPedido> itens)
        {
            return itens.Count(i => i.Tipo == tipo);
        }

        public void CalcularTotais(decimal desconto)
        {
            Subtotal = _itens.Sum(i => i.Preco);
            Desconto = desconto;
            Total = Subtotal - Desconto;
        }
    }
}
