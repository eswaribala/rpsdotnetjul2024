using Amazon.Auth.AccessControlPolicy;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OrderConsumerAPI.Models;
using OrderConsumerAPI.Repositories;

namespace OrderConsumerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderConsumerController : ControllerBase
    {

        private readonly IMongoRepository _mongoRepo;

        public OrderConsumerController(IMongoRepository mongoRepo)
        {
            _mongoRepo = mongoRepo;
        }


        // GET: api/Policies
        [HttpGet]
        public async Task<IEnumerable<Order>> GetOrders()
        {
            return await _mongoRepo.GetAllOrders();
        }


    } 
}
