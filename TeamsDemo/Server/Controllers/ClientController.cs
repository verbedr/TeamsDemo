using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;
using TeamsDemo.Server.Plugins;

namespace TeamsDemo.Server.Controllers
{
    [ApiController]
    [Route("api/client")]
    public class ClientController : ControllerBase
    {
        private readonly ILogger<ClientController> _logger;
        private readonly GraphClientAgent _agent;
        private readonly IMapper _mapper;
        private readonly IHubContext<SubscriptionHub> _hub;

        public ClientController(ILogger<ClientController> logger, GraphClientAgent agent, IMapper mapper, IHubContext<SubscriptionHub> hub)
        {
            _logger = logger;
            _agent = agent;
            _mapper = mapper;
            _hub = hub;
        }

        [HttpPost("meetnow")]
        public async Task<Shared.OnlineMeeting> Create()
        {
            var item = await _agent.StartOnlineMeeting();
            //var subscription = await _agent.CreateSubscription(item.ChatInfo.ThreadId);
            await _hub.Clients.All.SendAsync("notify", "connected");
            return _mapper.Map<Shared.OnlineMeeting>(item);
        }

        [HttpGet("chats")]
        public async Task<IEnumerable<Shared.Chat>> Chats()
        {
            var list = await _agent.ListChats();
            return _mapper.Map<IEnumerable<Shared.Chat>>(list);
        }

        
    }
}
