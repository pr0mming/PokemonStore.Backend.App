using MediatR;
using PokemonStore.Backend.Application.Common.Exceptions;
using PokemonStore.Backend.Domain.DTOs.Order.Requests;
using PokemonStore.Backend.Domain.Entities;
using PokemonStore.Backend.Domain.Interfaces;

namespace PokemonStore.Backend.Application.Order.Commands.CreateOrder
{
    public class CreateOrderCommand : IRequest<OrderEntity>
    {
        public CreateOrderRequestDTO Order { get; set; }
    }

    public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand, OrderEntity>
    {

        private readonly IProductOrderRepository _orderRepository;
        private readonly IProductRepository _productRepository;

        public CreateOrderCommandHandler(
            IProductOrderRepository orderRepository,
            IProductRepository productRepository) {

            _orderRepository = orderRepository;
            _productRepository = productRepository;

        }

        public async Task<OrderEntity> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
        {
            var newOrder = new OrderEntity();

            foreach (var item in request.Order.Items)
            {

                var product = await _productRepository.GetProductByIdAsync(item.ProductId);

                if (product == null)
                {
                    throw new NotFoundException(nameof(newOrder), item.ProductId);
                }

                newOrder.OrderItems.Add(new ProductOrderItem()
                {
                    Product = product,
                    Ammount = item.Ammount
                });
                
            }

            return await _orderRepository.CreateOrderAsync(newOrder);

        }
    }
}
