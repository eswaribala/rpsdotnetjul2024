using Confluent.Kafka;
using OrderPublisherAPI.Models;
using System.Diagnostics;
using System.Net;
#nullable disable
namespace OrderPublisherAPI.Services
{
    public class OrderService : IOrderService
    {
        public async Task<string> PublishOrderDetails(string order, IConfiguration configuration)
        {
            //producer configuration

            string topicName = configuration["TopicName"];

            ProducerConfig producerConfig = new ProducerConfig
            {
                BootstrapServers = configuration["BootStrapServer"],
                ClientId=Dns.GetHostName()
            };
            try
            {
                //publish the message
                using (var producer = new ProducerBuilder
               <Null, string>(producerConfig).Build())
                {
                    var result = await producer.ProduceAsync
                   (topicName, new Message<Null, string>
                   {
                       Value = order
                   });
                    Debug.WriteLine($"Delivery Timestamp:{result.Timestamp.UtcDateTime}");
                    return await Task.FromResult($"Delivery Timestamp:{result.Timestamp.UtcDateTime}");
                };              


            }
            catch (Exception ex) {
                Console.WriteLine($"Error occured: {ex.Message}");
            }
            return await Task.FromResult("Not Published.....");
        }
    }
}
