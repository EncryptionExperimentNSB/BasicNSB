using Hydrogen.ServiceBus.NServiceBus;
using NServiceBus;

namespace HostA
{
    public class EndpointConfig : IConfigureThisEndpoint
    {
        public void Customize(BusConfiguration configuration)
        {
            configuration.Conventions().MyDefaultConventions();
            configuration.EnableOutbox();
            configuration.EndpointName("EncryptionTest.HostB");
            configuration.UseTransport<RabbitMQTransport>();
            configuration.UsePersistence<InMemoryPersistence>();
        }
    }
}
