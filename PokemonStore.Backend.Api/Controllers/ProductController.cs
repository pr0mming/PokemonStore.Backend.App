using MediatR;
using Microsoft.AspNetCore.Mvc;
using PokemonStore.Backend.Application.Products.Commands.CreateProduct;
using PokemonStore.Backend.Application.Products.Commands.DeleteProduct;
using PokemonStore.Backend.Application.Products.Commands.EditProduct;
using PokemonStore.Backend.Application.Products.Queries.GetProductById;
using PokemonStore.Backend.Application.Products.Queries.GetProducts;
using PokemonStore.Backend.Domain.DTOs.Order.Requests;
using PokemonStore.Backend.Domain.Entities;

namespace PokemonStore.Backend.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : Controller
    {

        private readonly IMediator _mediator;

        public ProductController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<IList<ProductEntity>>> GetProductsList() {

            var result = await _mediator.Send(new GetProductsListQuery());

            return Ok(result);

        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProductEntity>> GetProductById(string id)
        {

            var result = await _mediator.Send(new GetProductByIdQuery() {  Id  = id});

            return Ok(result);

        }

        [HttpPost]
        public async Task<ActionResult<ProductEntity>> CreateProduct(CreateProductCommand command)
        {

            var result = await _mediator.Send(command);

            return Ok(result);

        }

        [HttpPatch("{id}")]
        public async Task<ActionResult<ProductEntity>> EditProduct(string id, CreateProductRequestDTO payload)
        {

            var result = await _mediator.Send(new UpdateProductCommand()
            {
                Id = id,
                Name= payload.Name,
                Description= payload.Description,
                Price = payload.Price
            });

            return Ok(result);

        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<string>> DeleteProduct(string id)
        {

            var result = await _mediator.Send(new DeleteProductCommand(id));

            return Ok(result);

        }
    }
}
