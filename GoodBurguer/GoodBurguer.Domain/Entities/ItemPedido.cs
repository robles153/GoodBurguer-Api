using GoodBurguer.GoodBurguer.Domain.Abstractions;
using GoodBurguer.GoodBurguer.Domain.Enums;
using GoodBurguer.GoodBurguer.Domain.Exceptions;

namespace GoodBurguer.GoodBurguer.Domain.Entities
{
    public class ItemPedido : EntityBase
    {
        #region EF
        protected ItemPedido() { }
        #endregion
        public Guid PedidoId { get; private set; }

        public string Nome { get; private set; }
        public decimal Preco { get; private set; }
        public TipoItem Tipo { get; private set; }

        public ItemPedido( string nome, decimal preco, TipoItem tipo)
        {
            if (string.IsNullOrWhiteSpace(nome))
                throw new DomainException("Nome do item inválido");

            if (preco <= 0)
                throw new DomainException("Preço do item inválido");
           
            Nome = nome;
            Preco = preco;
            Tipo = tipo;
        }
    }
}
