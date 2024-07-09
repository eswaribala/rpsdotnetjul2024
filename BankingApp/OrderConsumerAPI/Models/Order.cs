using MongoDB.Bson.Serialization.Attributes;

namespace OrderConsumerAPI.Models
{
    public enum OrderStatus
    {
        Pending, Processed, Cancelled
    }
    public class Order
    {
        [BsonId]
        public long OrderId { get; set; }
        public DateTime OrderDate { get; set; }
        public long OrderAmount { get; set; }

        public OrderStatus OrderStatus { get; set; }


    }
}
