using GoodBurguer.GoodBurguer.Domain.Entities;
using GoodBurguer.GoodBurguer.Domain.Enums;
using GoodBurguer.GoodBurguer.Domain.Exceptions;
using GoodBurguer.GoodBurguer.Domain.ValueObjects;
using GoodBurguer_Test.Builders;
using Xunit;

namespace GoodBurguer_Test.Pedidos
{
    public class PedidoTests
    {
        [Fact(DisplayName = "Deve lançar exceção ao criar pedido sem itens")]
        public void CriarPedido_DeveLancarExcecao_QuandoSemItens()
        {
            Assert.Throws<DomainException>(() =>
                new PedidoBuilder().Build()
            );
        }

        [Fact(DisplayName = "Deve lançar exceção ao criar pedido sem sanduíche")]
        public void CriarPedido_DeveLancarExcecao_QuandoSemSanduiche()
        {
            Assert.Throws<DomainException>(() =>
                new PedidoBuilder()
                    .ComBebida()
                    .Build()
            );
        }

        [Fact(DisplayName = "Deve lançar exceção ao criar pedido com mais de um sanduíche")]
        public void CriarPedido_DeveLancarExcecao_QuandoMaisDeUmSanduiche()
        {
            Assert.Throws<DomainException>(() =>
                new PedidoBuilder()
                    .ComSanduiche()
                    .ComSanduiche("X Bacon", 7.00m)
                    .Build()
            );
        }

        [Fact(DisplayName = "Deve lançar exceção ao criar pedido com mais de uma bebida")]
        public void CriarPedido_DeveLancarExcecao_QuandoMaisDeUmaBebida()
        {
            Assert.Throws<DomainException>(() =>
                new PedidoBuilder()
                    .ComSanduiche()
                    .ComBebida()
                    .ComBebida("Suco", 3.00m)
                    .Build()
            );
        }

        [Fact(DisplayName = "Deve lançar exceção ao criar pedido com mais de um acompanhamento")]
        public void CriarPedido_DeveLancarExcecao_QuandoMaisDeUmAcompanhamento()
        {
            Assert.Throws<DomainException>(() =>
                new PedidoBuilder()
                    .ComSanduiche()
                    .ComAcompanhamento()
                    .ComAcompanhamento("Onion Rings", 3.00m)
                    .Build()
            );
        }

        [Fact(DisplayName = "Deve criar pedido válido")]
        public void CriarPedido_DeveCriarComSucesso_QuandoValido()
        {
            var pedido = new PedidoBuilder()
                .ComSanduiche()
                .ComBebida()
                .Build();

            Assert.NotNull(pedido);
            Assert.Equal(2, pedido.Itens.Count);
        }

        [Fact(DisplayName = "Deve calcular totais corretamente")]
        public void CalcularTotais_DeveCalcularCorretamente()
        {
            var pedido = new PedidoBuilder()
                .ComSanduiche()   // 5.00
                .ComBebida()      // 2.50
                .Build();

            pedido.CalcularTotais(new Dinheiro(1.00m));

            Assert.Equal(7.50m, pedido.Subtotal.Valor);
            Assert.Equal(1.00m, pedido.Desconto.Valor);
            Assert.Equal(6.50m, pedido.Total.Valor);
        }

        [Fact(DisplayName = "Deve atualizar itens com sucesso quando válido")]
        public void AtualizarItens_DeveAtualizarComSucesso()
        {
            var pedido = new PedidoBuilder()
                .ComSanduiche()
                .Build();

            var novosItens = new PedidoBuilder()
                .ComSanduiche("X Bacon", 7.00m)
                .ComBebida()
                .Build()
                .Itens;

            pedido.AtualizarItens(novosItens);

            Assert.Equal(2, pedido.Itens.Count);
        }

        [Fact(DisplayName = "Deve lançar exceção ao atualizar com itens inválidos")]
        public void AtualizarItens_DeveLancarExcecao_QuandoInvalido()
        {
            var pedido = new PedidoBuilder()
                .ComSanduiche()
                .Build();

            var novosItens = new List<ItemPedido>
            {
                new ItemPedido("Refrigerante", 2.50m, TipoItem.Bebida) 
            };

            Assert.Throws<DomainException>(() =>
                pedido.AtualizarItens(novosItens)
            );
        }
    }
}