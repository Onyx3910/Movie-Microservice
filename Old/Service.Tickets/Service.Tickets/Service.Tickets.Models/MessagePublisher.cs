using RabbitMQ.Client;
using System;
using System.Text;
using System.Text.Json;

namespace Service.Tickets.Models
{
    public class MessagePublisher : QueueClient, IPublisher
    {
        public MessagePublisher() : base()
        {
            Channel.ExchangeDeclare(exchange: "direct_events", type: ExchangeType.Direct);
        }

        public void Publish<T>(T message)
        {
            var body = Encoding.UTF8.GetBytes(JsonSerializer.Serialize(message));
            Channel.BasicPublish(exchange: "direct_logs",
                     routingKey: nameof(T),
                     basicProperties: null,
                     body: body);
        }
    }
}
