using Confluent.Kafka;
using Frontliners.Assignment.Domain.Interfaces;
using Microsoft.Extensions.Logging;
using System.Text.Json;

namespace Frontliners.Assignment.Application.Services
{
    public class KafkaProxy : IKafkaProxy
    {
        private const string KafkaServer = "kafka1:19092";
        private readonly ILogger<KafkaProxy> _logger;

        public KafkaProxy(ILogger<KafkaProxy> logger)
        {
            _logger = logger;
        }

        public void Produce(string topic, IDomainEvent value)
        {
            var config = new ProducerConfig { BootstrapServers = KafkaServer, AllowAutoCreateTopics = true  };
            var serializedValue = JsonSerializer.Serialize(value);
            using (var producer = new ProducerBuilder<Null, string>(config).Build())
            {
                producer.Produce(topic, new Message<Null, string> { Value = serializedValue });
                producer.Flush();
            }
            _logger.LogInformation($"Message sent: {value}");
        }
    }
}
