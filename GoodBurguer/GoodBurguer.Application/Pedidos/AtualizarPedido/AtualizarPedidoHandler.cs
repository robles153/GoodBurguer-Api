using GoodBurguer.GoodBurguer.Application.DTOs.ResponseDtos.Pedido;
using GoodBurguer.GoodBurguer.Application.Interfaces;
using GoodBurguer.GoodBurguer.Domain.Entities;
using GoodBurguer.GoodBurguer.Domain.Exceptions;
using GoodBurguer.GoodBurguer.Domain.Strategies;
using GoodBurguer.GoodBurguer.Domain.ValueObjects;
using MediatR;

namespace GoodBurguer.GoodBurguer.Application.Pedidos.AtualizarPedido
{
    public class AtualizarPedidoHandler : IRequestHandler<AtualizarPedidoRequest, AtualizarPedidoResponse>
    {
        private readonly IPedidoRepository _pedidoRepository;
        private readonly IProdutoRepository _produtoRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IEnumerable<IDescontoStrategy> _strategies;
        private readonly ILogger<AtualizarPedidoHandler> _logger;

        public AtualizarPedidoHandler(IPedidoRepository pedidoRepository, IProdutoRepository produtoRepository, IUnitOfWork unitOfWork, IEnumerable<IDescontoStrategy> strategies, ILogger<AtualizarPedidoHandler> logger)
        {
            _pedidoRepository = pedidoRepository;
            _produtoRepository = produtoRepository;
            _unitOfWork = unitOfWork;
            _strategies = strategies;
            _logger = logger;
        }

        public async Task<AtualizarPedidoResponse> Handle(AtualizarPedidoRequest request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Atualizando pedido: {PedidoId}", request.PedidoId);

            var pedidoExistente = await _pedidoRepository.ObterPorIdAsync(request.PedidoId);

            if (pedidoExistente == null)
            {
                _logger.LogWarning("Pedido não encontrado: {PedidoId}", request.PedidoId);
                throw new DomainException("Pedido não encontrado");
            }

            var produtos = await ObterProdutos(request.ProdutoIds);

            var itens = MontarItensPedido(request.ProdutoIds, produtos);
            
            pedidoExistente.AtualizarItens(itens);

            var strategy = _strategies.FirstOrDefault(s => s.EhAplicavel(pedidoExistente))
                ?? throw new DomainException("Nenhuma regra de desconto aplicável");

            var desconto = strategy.CalcularDesconto(pedidoExistente);

            pedidoExistente.CalcularTotais(new Dinheiro(desconto));

            _pedidoRepository.Atualizar(pedidoExistente);

            await _unitOfWork.CommitAsync();

            _logger.LogInformation("Pedido atualizado com sucesso: {PedidoId}", request.PedidoId);

            return MapearResponse(pedidoExistente);
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
                    _logger.LogWarning("Produto não encontrado: {ProdutoId}", produtoId);
                    throw new DomainException($"Produto {produtoId} não encontrado");
                }

                itens.Add(new ItemPedido(
                    produto.Nome,
                    produto.Preco,
                    produto.Tipo
                ));
            }

            return itens;
        }

        private static AtualizarPedidoResponse MapearResponse(Pedido pedido)
        {
            return new AtualizarPedidoResponse
            {
                Pedido = new PedidoItemDto
                {
                    PedidoId = pedido.Id,
                    Subtotal = pedido.Subtotal.Valor,
                    Desconto = pedido.Desconto.Valor,
                    Total = pedido.Total.Valor
                }
            };
        }
    }
}
