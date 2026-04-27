using GoodBurguer.GoodBurguer.Domain.Entities;
using GoodBurguer.GoodBurguer.Domain.Enums;
using GoodBurguer.GoodBurguer.Domain.ValueObjects;

namespace GoodBurguer_Test.Builders
{
    public class PedidoBuilder
    {
        private readonly List<ItemPedido> _itens = new();

        public PedidoBuilder ComSanduiche(string nome = "X Burger", decimal preco = 5.00m)
        {
            _itens.Add(new ItemPedido(nome, preco, TipoItem.Sanduiche));
            return this;
        }

        public PedidoBuilder ComBebida(string nome = "Refrigerante", decimal preco = 2.50m)
        {
            _itens.Add(new ItemPedido(nome, preco, TipoItem.Bebida));
            return this;
        }

        public PedidoBuilder ComAcompanhamento(string nome = "Batata frita", decimal preco = 2.00m)
        {
            _itens.Add(new ItemPedido(nome, preco, TipoItem.Acompanhamento));
            return this;
        }       

        public Pedido Build()
        {
            var pedido = new Pedido(_itens);
           
            pedido.CalcularTotais(new Dinheiro(0));

            return pedido;
        }
    }
}