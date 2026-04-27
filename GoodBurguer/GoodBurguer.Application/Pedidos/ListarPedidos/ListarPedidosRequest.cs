using MediatR;

namespace GoodBurguer.GoodBurguer.Application.Pedidos.ListarPedidos
{
    public class ListarPedidosRequest : IRequest<ListarPedidosResponse>
    {
        public int Page { get; }
        public int PageSize { get; }

        public ListarPedidosRequest(int page, int pageSize)
        {
            Page = page <= 0 ? 1 : page;

            PageSize = pageSize <= 0
                ? 10
                : pageSize > 50
                    ? 50
                    : pageSize;
        }
    }
}
