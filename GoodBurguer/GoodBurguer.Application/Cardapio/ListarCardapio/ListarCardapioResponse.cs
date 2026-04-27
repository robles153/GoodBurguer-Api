using GoodBurguer.GoodBurguer.Application.DTOs.ResponseDtos.Cardapio;

namespace GoodBurguer.GoodBurguer.Application.Cardapio.ListarCardapio
{
    public class ListarCardapioResponse
    {
        public IEnumerable<CardapioItemDto> Itens { get; set; } = new List<CardapioItemDto>();
    }
}
