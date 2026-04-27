using GoodBurguer.GoodBurguer.Application.DTOs.ResponseDtos.Cardapio;
using GoodBurguer.GoodBurguer.Application.Interfaces;
using MediatR;

namespace GoodBurguer.GoodBurguer.Application.Cardapio.ListarCardapio
{
    public class ListarCardapioHandler : IRequestHandler<ListarCardapioRequest, ListarCardapioResponse>
    {
        private readonly IProdutoRepository _produtoRepository;
        private readonly ILogger<ListarCardapioHandler> _logger;

        public ListarCardapioHandler(IProdutoRepository produtoRepository, ILogger<ListarCardapioHandler> logger)
        {
            _produtoRepository = produtoRepository;
            _logger = logger;
        }


        public async Task<ListarCardapioResponse> Handle(ListarCardapioRequest request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Listando cardápio");

            var produtos = await _produtoRepository.ListarAsync();

            var itens = produtos.Select(p => new CardapioItemDto
            {
                Id = p.Id,
                Nome = p.Nome,
                Preco = p.Preco,
                Tipo = p.Tipo.ToString()
            });

            return new ListarCardapioResponse
            {
                Itens = itens
            };
        }
    }
}
