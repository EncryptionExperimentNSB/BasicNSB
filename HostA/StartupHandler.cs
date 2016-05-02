using Models;
using NServiceBus;
using System;

namespace HostA
{
    public class StartupHandler : IWantToRunWhenBusStartsAndStops
    {
        private readonly IBus _bus;

        public StartupHandler(IBus bus)
        {
            _bus = bus;
        }

        public void Start()
        {
            var comandb = new CommandB
            {
                Id = Guid.NewGuid(),
                DoB = DateTime.UtcNow,
                Name = "Trevor"
            };

            _bus.Send("HostB", comandb);
        }

        public void Stop()
        {
            return;
        }
    }
}
