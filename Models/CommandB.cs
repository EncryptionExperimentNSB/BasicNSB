using Newtonsoft.Json;
using NServiceBus;
using System;

namespace Models
{
    public class CommandB : ICommand
    {
        [JsonProperty]
        public Guid Id { get; set; }

        [JsonProperty]
        public DateTime DoB { get; set; }

        [JsonProperty]
        public string Name { get; set; }
    }
}
