using RabbitMQ.Client;
using System;

namespace Service.Tickets.Models
{
    public abstract class QueueClient : IDisposable
    {
        public QueueClient()
        {
            var factory = new ConnectionFactory() { HostName = "localhost" };
            Connection = factory.CreateConnection();
            Channel = Connection.CreateModel();
        }

        protected IConnection Connection { get; init; }
        protected IModel Channel { get; init; }

        public void Dispose()
        {
            Connection.Dispose();
            Channel.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
