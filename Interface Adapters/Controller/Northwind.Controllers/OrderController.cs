using MediatR;
using Microsoft.AspNetCore.Mvc;
using Northwind.Presenters;
using Northwind.UseCases.CreateOrder;
using Northwind.UseCasesDTOs.CreateOrder;
using System.Threading.Tasks;

namespace Northwind.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController
    {
        readonly IMediator _mediator;
        public OrderController(IMediator mediator) => _mediator = mediator;
        [HttpPost("create-order")]
        public async Task<string> CreateOrder(CreateOrderParams orderParams)
        {
            CreateOrderPresenter presenter = new CreateOrderPresenter();
            await _mediator.Send(new CreateOrderInputPort(orderParams, presenter));
            return presenter.Content;
        }
    }
}
