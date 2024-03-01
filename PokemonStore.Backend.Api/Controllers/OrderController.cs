using MediatR;
using Microsoft.AspNetCore.Mvc;
using PokemonStore.Backend.Application.Order.Commands.CreateOrder;
using PokemonStore.Backend.Application.Order.Queries.GetOrders;
using PokemonStore.Backend.Domain.Entities;

namespace PokemonStore.Backend.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : Controller
    {
        
        private readonly IMediator _mediator;

        public OrderController(IMediator mediator)
        {
            _mediator= mediator;
        }

        [HttpGet]
        public async Task<ActionResult<IList<OrderEntity>>> GetOrdersList()
        {

            var result = await _mediator.Send(new GetOrdersListQuery());

            return Ok(result);

        }

        [HttpPost]
        public async Task<ActionResult<OrderEntity>> CreateOrder(CreateOrderCommand command)
        {

            var result = await _mediator.Send(command);

            return Ok(result);

        }
    }
}
