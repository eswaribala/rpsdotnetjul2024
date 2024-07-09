using OrderConsumerAPI.Models;

namespace OrderConsumerAPI.Repositories
{
    public interface IMongoRepository
    {
        void AddOrder(Order Order);
        Task<IEnumerable<Order>> GetAllOrders();

    }
}
