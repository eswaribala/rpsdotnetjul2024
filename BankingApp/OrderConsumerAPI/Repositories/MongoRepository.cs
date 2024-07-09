using MongoDB.Driver;
using OrderConsumerAPI.Models;

namespace OrderConsumerAPI.Repositories
{
    public class MongoRepository : IMongoRepository
    {
        private readonly IConfiguration _configuration;
        private readonly IMongoCollection<Order> _ordersCollection;
        public MongoRepository(IConfiguration configuration)
        {
            _configuration = configuration;

            var mongoClient = new MongoClient(_configuration["ConnectionString"]);

            var database = mongoClient.GetDatabase(_configuration["DatabaseName"]);

            _ordersCollection = database.GetCollection<Order>(
             _configuration["OrdersCollectionName"]);

        }
        public async void AddOrder(Order Order)
        {
           await  _ordersCollection.InsertOneAsync(Order);
        }

        public async Task<IEnumerable<Order>> GetAllOrders()
        {
            var filter = Builders<Order>.Filter.Empty;
            var allOrders = await _ordersCollection.FindAsync(filter);
            return allOrders.ToList();
           
        }
    }
}
