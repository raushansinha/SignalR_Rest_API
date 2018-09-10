using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SignalRHub
{
    public interface ITypedHubClient
    {
        Task BroadcastMessage(string type, string payload);
        Task BroadcastWarning(string type, string payload);
    }
}
