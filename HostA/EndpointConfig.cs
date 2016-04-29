using System.Configuration;
using Autofac;
using NServiceBus.Log4Net;
using NServiceBus.Logging;

namespace HostA
{
    using NServiceBus;

    /*
		This class configures this endpoint as a Server. More information about how to configure the NServiceBus host
		can be found here: http://particular.net/articles/the-nservicebus-host
	*/
    public class EndpointConfig : IConfigureThisEndpoint
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
