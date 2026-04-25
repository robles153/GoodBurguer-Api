using GoodBurguer.GoodBurguer.Application.Interfaces;
using GoodBurguer.GoodBurguer.Domain.Entities;
using GoodBurguer.GoodBurguer.Domain.Exceptions;
using GoodBurguer.GoodBurguer.Domain.Strategies;
using GoodBurguer.GoodBurguer.Domain.ValueObjects;
using MediatR;

namespace GoodBurguer.GoodBurguer.Application.Pedidos.CriarPedido
{
    public class CriarPedidoHandler : IRequestHandler<CriarPedidoRequest, CriarPedidoResponse>
    {
        private readonly IProdutoRepository _produtoRepository;
        private readonly IPedidoRepository _pedidoRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IEnumerable<IDescontoStrategy> _strategies;
        private readonly ILogger<CriarPedidoHandler> _logger;

        public CriarPedidoHandler(IProdutoRepository produtoRepository, IPedidoRepository pedidoRepository, IUnitOfWork unitOfWork, IEnumerable<IDescontoStrategy> strategies, ILogger<CriarPedidoHandler> logger)
        {
            _produtoRepository = produtoRepository;
            _pedidoRepository = pedidoRepository;
            _unitOfWork = unitOfWork;
            _strategies = strategies;
            _logger = logger;
        }

        public async Task<CriarPedidoResponse> Handle(CriarPedidoRequest request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Iniciando criação de pedido. Quantidade de produtos: {Quantidade}", request.ProdutoIds.Count());

            var produtos = await ObterProdutos(request.ProdutoIds);

            var itens = MontarItensPedido(request.ProdutoIds, produtos);

            var pedido = new Pedido(itens);

            var strategy = _strategies.First(s => s.EhAplicavel(pedido));
            var desconto = strategy.CalcularDesconto(pedido);

            _logger.LogInformation("Strategy aplicada: {Strategy}", strategy.GetType().Name);

            pedido.CalcularTotais(new Dinheiro(desconto));

            await _pedidoRepository.AdicionarAsync(pedido);
            await _unitOfWork.CommitAsync();

            _logger.LogInformation("Pedido criado com sucesso. PedidoId: {PedidoId}", pedido.Id);

            return MapearResponse(pedido);
        }

        private static CriarPedidoResponse MapearResponse(Pedido pedido)
        {
            return new CriarPedidoResponse
            {
                PedidoId = pedido.Id,
                Subtotal = pedido.Subtotal.Valor,
                Desconto = pedido.Desconto.Valor,
                Total = pedido.Total.Valor
            };
        }

        private async Task<IEnumerable<Produto>> ObterProdutos(IEnumerable<Guid> ids)
        {
            var produtos = await _produtoRepository.ObterPorIdsAsync(ids);

            if (produtos == null || !produtos.Any())
                throw new DomainException("Nenhum produto encontrado");

            return produtos;
        }

        private List<ItemPedido> MontarItensPedido(IEnumerable<Guid> produtoIds, IEnumerable<Produto> produtos)
        {
            var produtosDict = produtos.ToDictionary(p => p.Id);
            var itens = new List<ItemPedido>();

            foreach (var produtoId in produtoIds)
            {
                if (!produtosDict.TryGetValue(produtoId, out var produto))
                {
                    _logger.LogWarning("Produto não encontrado ao montar itens. Id: {ProdutoId}", produtoId);
                    throw new DomainException($"Produto {produtoId} não encontrado");
                }

                _logger.LogDebug("Adicionando item ao pedido. ProdutoId: {ProdutoId}, Nome: {Nome}", produto.Id, produto.Nome);

                itens.Add(new ItemPedido(
                    produto.Nome,
                    produto.Preco,
                    produto.Tipo
                ));
            }

            return itens;
        }
    }
}
