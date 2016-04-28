using System;
using HostA;
using NServiceBus;
using log4net;

namespace HostB
{
    public class CommandBHandler : IHandleMessages<CommandB>
    {
        private readonly ILog logger = LogManager.GetLogger(typeof(CommandBHandler));
        public void Handle(CommandB message)
        {
            logger.Info("Id: " + message.Id.ToString("D") + "DoB: " + message.DoB.ToString("yyyy-MM-dd HH:mm:ss") + "Name: " + message.Name);
        }
    }
}
