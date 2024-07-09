namespace OrderPublisherAPI.Models
{
    public enum OrderStatus
    {
        Pending,Processed,Cancelled
    }
    public class Order
    {
        public long OrderId {  get; set; }
        public DateTime OrderDate {  get; set; }
        public long OrderAmount {  get; set; }

        public OrderStatus OrderStatus { get; set; }    


    }
}
