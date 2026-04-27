namespace GoodBurguer.GoodBurguer.Application.DTOs.ResponseDtos.Cardapio
{
    public class CardapioItemDto
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public decimal Preco { get; set; }
        public string Tipo { get; set; }
    }
}
