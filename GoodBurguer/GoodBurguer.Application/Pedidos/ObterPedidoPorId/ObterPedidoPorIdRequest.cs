using MediatR;

namespace GoodBurguer.GoodBurguer.Application.Pedidos.ObterPedidoPorId
{
    public class ObterPedidoPorIdRequest : IRequest<ObterPedidoPorIdResponse>
    {
        public Guid Id { get; }

        public ObterPedidoPorIdRequest(Guid id)
        {
            Id = id;
        }
    }
}
