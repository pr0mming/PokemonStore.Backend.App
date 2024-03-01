using MediatR;
using PokemonStore.Backend.Application.Common.Exceptions;
using PokemonStore.Backend.Domain.Entities;
using PokemonStore.Backend.Domain.Interfaces;

namespace PokemonStore.Backend.Application.Products.Commands.EditProduct
{
    public class UpdateProductCommand : IRequest<ProductEntity>
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public long Price { get; set; }
    }

    public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand, ProductEntity> 
    {

        private readonly IProductRepository _productRepository;

        public UpdateProductCommandHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<ProductEntity> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {

            var product = await _productRepository.GetProductByIdAsync(request.Id);

            if (product == null)
            {
                throw new NotFoundException(nameof(product), request.Id);
            }

            product.Name = request.Name;
            product.Description = request.Description;
            product.Price = request.Price;

            return await _productRepository.UpdateProductAsync(product);

        }
    }

}
