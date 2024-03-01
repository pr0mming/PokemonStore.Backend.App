using MediatR;
using PokemonStore.Backend.Domain.Entities;
using PokemonStore.Backend.Domain.Interfaces;

namespace PokemonStore.Backend.Application.Order.Queries.GetOrders
{
    public record GetOrdersListQuery : IRequest<List<OrderEntity>>;

    public class GetOrdersListQueryHandler : IRequestHandler<GetOrdersListQuery, List<OrderEntity>>
    {

        private readonly IProductOrderRepository _orderRepository;

        public GetOrdersListQueryHandler(IProductOrderRepository orderRepository)
        {
            _orderRepository= orderRepository;
        }

        public Task<List<OrderEntity>> Handle(GetOrdersListQuery request, CancellationToken cancellationToken)
        {
            return _orderRepository.GetOrdersListAsync();
        }
    }
}
