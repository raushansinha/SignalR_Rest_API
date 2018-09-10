using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SignalRHub
{
    [Route("api/[controller]")]
    public class NotificationController : Controller
    {

        //referencing NotifyHub & ITypedHubClient using SignalR IHubContext
        private IHubContext<NotifyHub, ITypedHubClient> _hubContext;

        public NotificationController(IHubContext<NotifyHub, ITypedHubClient> hubContext)
        {
            _hubContext = hubContext;
        }

       
        [HttpPost]
        [ActionName("PushMessage")]
        public string Post([FromBody]Message msg)
        {
            string retMessage = string.Empty;
            try
            {
                switch(msg.Type)
                {
                    case MessageType.success:
                        _hubContext.Clients.All.BroadcastMessage(msg.Type.ToString(), msg.Payload);
                        retMessage = "Success Sent Successfully";
                        break;
                    case MessageType.warning:
                        _hubContext.Clients.All.BroadcastWarning(msg.Type.ToString(), msg.Payload);
                        retMessage = "Warning Sent Successfully";
                        break;
                    default:
                        break;
                }
            }
            catch (Exception e)
            {
                retMessage = e.ToString();
            }
            return retMessage;
        }
    }
}
