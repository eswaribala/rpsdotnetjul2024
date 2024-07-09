using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OrderPublisherAPI.Models;
using OrderPublisherAPI.Services;
using System.Text.Json;

namespace OrderPublisherAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderPublisherController : ControllerBase
    {

        private readonly IConfiguration _configuration;
        private readonly IOrderService _orderService;
        public OrderPublisherController(IConfiguration configuration, IOrderService orderService)
        {
            _configuration = configuration;
            _orderService = orderService;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Order order)
        {           
           string orderObj = JsonSerializer.Serialize(order);
            return Ok(await _orderService.PublishOrderDetails(orderObj, _configuration));

        }
    }
}
