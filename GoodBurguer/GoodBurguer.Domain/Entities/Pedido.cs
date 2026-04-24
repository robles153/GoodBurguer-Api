using GoodBurguer.GoodBurguer.Domain.Abstractions;
using GoodBurguer.GoodBurguer.Domain.Enums;
using GoodBurguer.GoodBurguer.Domain.Exceptions;
using GoodBurguer.GoodBurguer.Domain.ValueObjects;

namespace GoodBurguer.GoodBurguer.Domain.Entities
{
    public class Pedido : AggregateRoot
    {
        #region EF
        protected Pedido() { }
        #endregion

        private readonly List<ItemPedido> _itens = new();

        public IReadOnlyCollection<ItemPedido> Itens => _itens;

        public Dinheiro Subtotal { get; private set; } = Dinheiro.Zero;
        public Dinheiro Desconto { get; private set; } = Dinheiro.Zero;
        public Dinheiro Total { get; private set; } = Dinheiro.Zero;

        public Pedido(IEnumerable<ItemPedido> itens)
        {
            Validar(itens);

            foreach (var item in itens)
            {
                AdicionarItem(item);
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

        private void AdicionarItem(ItemPedido item)
        {
            if (item == null)
                throw new DomainException("Item inválido");

            _itens.Add(item);
        }

        private int ContarItensPorTipo(TipoItem tipo, IEnumerable<ItemPedido> itens)
        {
            return itens.Count(i => i.Tipo == tipo);
        }

        public void CalcularTotais(Dinheiro desconto)
        {
            var subtotal = new Dinheiro(_itens.Sum(i => i.Preco));

            Subtotal = subtotal;
            Desconto = desconto;
            Total = Subtotal - Desconto;
        }
    }
}
