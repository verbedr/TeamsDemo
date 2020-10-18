using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TeamsDemo.Server.Plugins;

namespace TeamsDemo.Server.Controllers
{
    [ApiController]
    [Route("api/user")]
    public class UserController : ControllerBase
    {
        private readonly GraphUserAgent _agent;
        private readonly IMapper _mapper;

        public UserController(GraphUserAgent agent, IMapper mapper)
        {
            _agent = agent;
            _mapper = mapper;
        }

        [HttpPost("meetnow")]
        public async Task<Shared.OnlineMeeting> Create()
        {
            var item = await _agent.StartOnlineMeeting();
            return _mapper.Map<Shared.OnlineMeeting>(item);
        }

        [HttpGet("meetnow/{id}")]
        public async Task<Shared.OnlineMeeting> Get(string id)
        {
            var item = await _agent.OnlineMeeting(id);
            return _mapper.Map<Shared.OnlineMeeting>(item);
        }


        [HttpGet("chats")]
        public async Task<List<Shared.Chat>> Chats()
        {
            var list = await _agent.ListChats();
            return _mapper.Map<List<Shared.Chat>>(list).OrderByDescending(x => x.CreatedDateTime).Take(20).ToList();
        }

        [HttpGet("chats/{id}/members")]
        public async Task<List<Shared.ConversationMember>> ChatMembers(string id)
        {
            var list = await _agent.ListChatMembers(id);
            return _mapper.Map<List<Shared.ConversationMember>>(list);
        }

        [HttpGet("chats/{id}/messages")]
        public async Task<List<Shared.ChatMessage>> ChatMessages(string id)
        {
            var list = await _agent.ListChatMessages(id);
            return _mapper.Map<List<Shared.ChatMessage>>(list);
        }
    }
}
