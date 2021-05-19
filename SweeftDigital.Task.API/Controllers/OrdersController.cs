using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SweeftDigital.Task.API.Models.Orders;
using SweeftDigital.Task.Application.Services.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SweeftDigital.Task.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderService _orderSevices;

        public OrdersController(IOrderService orderService)
        {
            _orderSevices = orderService;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateOrderRequest request)
        {
            var id = await _orderSevices.AddOrderAsync(request.Order);

            return Ok(new
            {
                Data = id
            });
        }

        [HttpPut("{id}/mark-as-approved")]
        public async Task<IActionResult> MarkOrderAsApproved(int id)
        {
            await _orderSevices.ApproveOrderAsync(id);

            return Ok();
        }

    }
}
