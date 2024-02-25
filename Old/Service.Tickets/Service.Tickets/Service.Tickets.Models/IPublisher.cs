namespace Service.Tickets.Models
{
    public interface IPublisher
    {
        void Publish<T>(T message);
    }
}