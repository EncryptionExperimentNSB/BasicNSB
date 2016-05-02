using NServiceBus;
using NServiceBus.Log4Net;
using NServiceBus.Logging;
using System.Configuration;

namespace HostB
{
    public class HostBEndpointConfig : IConfigureThisEndpoint
    {
        public void Customize(BusConfiguration configuration)
        {
            LogManager.Use<Log4NetFactory>();

            configuration.EnableOutbox();
            configuration.UsePersistence<InMemoryPersistence>();
            configuration.EndpointName("HostB");
            configuration.UseSerialization<JsonSerializer>();
            configuration.EnableInstallers();
            configuration.AssembliesToScan(typeof(NServiceBus.Transports.RabbitMQ.IManageRabbitMqConnections).Assembly, typeof(Newtonsoft.Json.Linq.JObject).Assembly);

            var transport = configuration.UseTransport<RabbitMQTransport>();

            var transportConnectionString = ConfigurationManager.ConnectionStrings["NServiceBus/Transport"].ConnectionString;

            if (!string.IsNullOrEmpty(transportConnectionString))
            {
                transport.ConnectionString(transportConnectionString);
            }
        }
    }
}
