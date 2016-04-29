using System;
using NServiceBus;

namespace HostA
{
   public class CommandB : ICommand
   {
        public Guid Id { get; set; }
        public DateTime DoB { get; set; }
        public string Name { get; set; }
   }
}
