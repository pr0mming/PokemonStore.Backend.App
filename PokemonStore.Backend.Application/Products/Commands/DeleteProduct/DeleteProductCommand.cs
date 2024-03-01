using MediatR;
using PokemonStore.Backend.Application.Common.Exceptions;
using PokemonStore.Backend.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonStore.Backend.Application.Products.Commands.DeleteProduct
{
    public record DeleteProductCommand(string Id) : IRequest<string>;

    public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommand, string>
    {

        private readonly IProductRepository _productRepository;

        public DeleteProductCommandHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<string> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            var product = await _productRepository.GetProductByIdAsync(request.Id);

            if (product == null)
            {
                throw new NotFoundException(nameof(product), request.Id);
            }

            product.IsActive = false;

            await _productRepository.UpdateProductAsync(product);

            return product.Id;
        }
    }
}
