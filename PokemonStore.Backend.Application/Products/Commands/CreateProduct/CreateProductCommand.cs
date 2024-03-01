using MediatR;
using PokemonStore.Backend.Domain.DTOs.Order.Requests;
using PokemonStore.Backend.Domain.Entities;
using PokemonStore.Backend.Domain.Interfaces;

namespace PokemonStore.Backend.Application.Products.Commands.CreateProduct
{
    public class CreateProductCommand : IRequest<ProductEntity>
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public long Price { get; set; }

        public string ImageURL { get; set; }        
    }

    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, ProductEntity>
    {

        private readonly IProductRepository _productRepository;

        public CreateProductCommandHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<ProductEntity> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {

            var newProduct = new ProductEntity()
            {
                Name = request.Name,
                Description = request.Description,
                ImageURL = request.ImageURL,
                Price = request.Price,
                IsActive = true
            };

            return await _productRepository.CreateProductAsync(newProduct);

        }
    }
}
