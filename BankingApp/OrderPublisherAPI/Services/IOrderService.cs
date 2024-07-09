using OrderPublisherAPI.Models;

namespace OrderPublisherAPI.Services
{
    public interface IOrderService
    {
        Task<string> PublishOrderDetails(string order, IConfiguration configuration);
    }
}
