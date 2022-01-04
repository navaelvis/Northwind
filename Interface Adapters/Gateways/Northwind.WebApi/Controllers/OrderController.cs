using MediatR;
using Microsoft.AspNetCore.Mvc;
using Northwind.UseCases.CreateOrder;
using System.Threading.Tasks;

namespace Northwind.WebApi.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        readonly IMediator _mediator;
        public OrderController(IMediator mediator) => _mediator = mediator;
        [HttpPost("create-order")]
        public async Task<ActionResult<int>> CreateOrder(
            CreateOrderInputPort orderInputPort)
        {
            return await _mediator.Send(orderInputPort);
        }
    }
}