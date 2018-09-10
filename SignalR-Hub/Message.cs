using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SignalRHub
{
    public class Message
    {
        public MessageType Type { get; set; }
        public string Payload { get; set; }
    }

    public enum MessageType
    {
        success,
        warning,
        error
    }
}
