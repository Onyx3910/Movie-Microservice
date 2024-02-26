namespace Company.Consumers
{
    using System.Threading.Tasks;
    using MassTransit;
    using Contracts;

    public class Audit.ConsumerConsumer :
        IConsumer<Audit.Consumer>
    {
        public Task Consume(ConsumeContext<Audit.Consumer> context)
        {
            return Task.CompletedTask;
        }
    }
}