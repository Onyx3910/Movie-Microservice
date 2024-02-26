namespace Company.Consumers
{
    using MassTransit;

    public class Audit.ConsumerConsumerDefinition :
        ConsumerDefinition<Audit.ConsumerConsumer>
    {
        protected override void ConfigureConsumer(IReceiveEndpointConfigurator endpointConfigurator, IConsumerConfigurator<Audit.ConsumerConsumer> consumerConfigurator)
        {
            endpointConfigurator.UseMessageRetry(r => r.Intervals(500, 1000));
        }
    }
}