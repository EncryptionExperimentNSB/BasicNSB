using System.Configuration;
using Autofac;
using NServiceBus.Log4Net;
using NServiceBus.Logging;
using NServiceBus;

namespace HostA
{
    public class HostAEndpointConfig : IConfigureThisEndpoint
    {
        public void Customize(BusConfiguration configuration)
        {
            var builder = new ContainerBuilder();
            var container = builder.Build();

            LogManager.Use<Log4NetFactory>();

            configuration.EnableOutbox();
            configuration.UseContainer<AutofacBuilder>(c => c.ExistingLifetimeScope(container));
            configuration.UsePersistence<InMemoryPersistence>();
            configuration.EndpointName("HostA");
            configuration.UseSerialization<JsonSerializer>();
            configuration.EnableInstallers();

            var transport = configuration.UseTransport<RabbitMQTransport>();

            var transportConnectionString = ConfigurationManager.ConnectionStrings["NServiceBus/Transport"].ConnectionString;

            if (!string.IsNullOrEmpty(transportConnectionString))
            {
                transport.ConnectionString(transportConnectionString);
            }
        }
    }
}
