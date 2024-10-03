
namespace Frontliners.Assignment.Domain.Interfaces
{
    public interface IKafkaProxy
    {
        public void Produce(string topic, IDomainEvent value);
    }
}
