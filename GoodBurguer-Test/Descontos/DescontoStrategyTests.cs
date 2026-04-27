using GoodBurguer.GoodBurguer.Domain.Strategies;
using GoodBurguer_Test.Builders;

namespace GoodBurguer_Test.Descontos
{
    public class DescontoStrategyTests
    {
        [Fact(DisplayName = "Deve aplicar 20% de desconto no combo completo")]
        public void DeveAplicarDesconto_ComboCompleto()
        {
            var pedido = new PedidoBuilder()
                .ComSanduiche()
                .ComBebida()
                .ComAcompanhamento()
                .Build();

            var strategy = new DescontoComboCompleto();

            Assert.True(strategy.EhAplicavel(pedido));

            var desconto = strategy.CalcularDesconto(pedido);

            Assert.Equal((5.00m + 2.50m + 2.00m) * 0.20m, desconto);
        }

        [Fact(DisplayName = "Deve aplicar 15% para sanduíche + bebida")]
        public void DeveAplicarDesconto_SanduicheEBebida()
        {
            var pedido = new PedidoBuilder()
                .ComSanduiche()
                .ComBebida()
                .Build();

            var strategy = new DescontoSanduicheBebida();

            Assert.True(strategy.EhAplicavel(pedido));

            var desconto = strategy.CalcularDesconto(pedido);

            Assert.Equal((5.00m + 2.50m) * 0.15m, desconto);
        }

        [Fact(DisplayName = "Deve aplicar 10% para sanduíche + acompanhamento")]
        public void DeveAplicarDesconto_SanduicheEAcompanhamento()
        {
            var pedido = new PedidoBuilder()
                .ComSanduiche()
                .ComAcompanhamento()
                .Build();

            var strategy = new DescontoSanduicheAcompanhamento();

            Assert.True(strategy.EhAplicavel(pedido));

            var desconto = strategy.CalcularDesconto(pedido);

            Assert.Equal((5.00m + 2.00m) * 0.10m, desconto);
        }

        [Fact(DisplayName = "Não deve aplicar desconto para combo completo quando não elegível")]
        public void ComboCompleto_NaoAplicavel()
        {
            var pedido = new PedidoBuilder()
                .ComSanduiche()
                .Build();

            var strategy = new DescontoComboCompleto();

            Assert.False(strategy.EhAplicavel(pedido));
        }

        [Fact(DisplayName = "Não deve aplicar desconto sanduíche + bebida quando tem acompanhamento")]
        public void SanduicheEBebida_NaoAplicavel_ComAcompanhamento()
        {
            var pedido = new PedidoBuilder()
                .ComSanduiche()
                .ComBebida()
                .ComAcompanhamento()
                .Build();

            var strategy = new DescontoSanduicheBebida();

            Assert.False(strategy.EhAplicavel(pedido));
        }

        [Fact(DisplayName = "Sem desconto sempre aplicável")]
        public void SemDesconto_SempreAplicavel()
        {
            var pedido = new PedidoBuilder()
                .ComSanduiche()
                .Build();

            var strategy = new SemDescontoStrategy();

            Assert.True(strategy.EhAplicavel(pedido));
        }

        [Fact(DisplayName = "Sem desconto deve retornar 0")]
        public void SemDesconto_DeveRetornarZero()
        {
            var pedido = new PedidoBuilder()
                .ComSanduiche()
                .Build();

            var strategy = new SemDescontoStrategy();

            var desconto = strategy.CalcularDesconto(pedido);

            Assert.Equal(0, desconto);
        }
    }
}