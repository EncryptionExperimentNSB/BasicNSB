using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NServiceBus;

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
            CommandB comandb = new CommandB();
            _bus.Send(comandb);
        }

        public void Stop()
        {
            return;
        }
    }
}
