using NServiceBus;
using Hydrogen.ServiceBus.NServiceBus;
using NServiceBus.Log4Net;
using NServiceBus.Logging;
using NServiceBus.Persistence.MongoDB;

namespace HostB
{
    public class EndpointConfig : IConfigureThisEndpoint
    {
        public void Customize(BusConfiguration configuration)
        {
            LogManager.Use<Log4NetFactory>();
            configuration.Conventions().MyDefaultConventions();
            configuration.EnableOutbox();
            configuration.EndpointName("EncryptionTest.HostB");
            configuration.UsePersistence<MongoDbPersistence>();
            configuration.UseTransport<RabbitMQTransport>();
        }
    }
}
