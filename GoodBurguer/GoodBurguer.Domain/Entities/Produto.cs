using GoodBurguer.GoodBurguer.Domain.Abstractions;
using GoodBurguer.GoodBurguer.Domain.Enums;
using GoodBurguer.GoodBurguer.Domain.Exceptions;

namespace GoodBurguer.GoodBurguer.Domain.Entities
{
    public class Produto : EntityBase
    {
        #region EF
        protected Produto() { }
        #endregion

        public string Nome { get; private set; }
        public decimal Preco { get; private set; }
        public TipoItem Tipo { get; private set; }
        public bool Ativo { get; private set; }

        public Produto(string nome, decimal preco, TipoItem tipo)
        {
            if (string.IsNullOrWhiteSpace(nome))
                throw new DomainException("Nome inválido");

            if (preco <= 0)
                throw new DomainException("Preço inválido");

            Nome = nome;
            Preco = preco;
            Tipo = tipo;
            Ativo = true;
        }

        public void AtualizarPreco(decimal novoPreco)
        {
            if (novoPreco <= 0)
                throw new DomainException("Preço inválido");

            Preco = novoPreco;
        }

        public void Desativar()
        {
            Ativo = false;
        }
    }
}
