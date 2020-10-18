using System;
using System.Net;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.Graph;
using Microsoft.Graph.Auth;

namespace TeamsDemo.Server.Plugins
{
    public class GraphUserAgent : GraphServiceClient
    {
        private readonly IOptions<TeamsDemoOption> _options;

        public GraphUserAgent(UsernamePasswordProvider authenticationProvider, IOptions<TeamsDemoOption> options,
            ILogger<GraphClientAgent> logger) 
            : base(authenticationProvider.CreateGraphClient(logger))
        {
            _options = options;
        }

        internal async Task<OnlineMeeting> GetMeetNowAsync(string meetNowId)
        {
            return await Communications.OnlineMeetings[meetNowId].Request().GetAsync();
        }

        public async Task<OnlineMeeting> StartOnlineMeeting()
        {
            var request = new OnlineMeeting
            {
                StartDateTime = DateTime.UtcNow,
                EndDateTime = DateTime.UtcNow.AddHours(1),
                Subject = "Meeting hosted by Dries as a test",
                AccessLevel = AccessLevel.Everyone,
            };

            return await Me.OnlineMeetings.Request()
                .WithUsernamePassword(_options.Value.Email, new NetworkCredential("", _options.Value.Password).SecurePassword)
                .AddAsync(request);
        }

        public async Task<OnlineMeeting> OnlineMeeting(string id)
        {
            var onlineMeeting = await Me.OnlineMeetings[id].Request()
                .WithUsernamePassword(_options.Value.Email, new NetworkCredential("", _options.Value.Password).SecurePassword)
                .GetAsync();
            return onlineMeeting;
        }

        public async Task<IUserChatsCollectionPage> ListChats()
        {
            return await Me.Chats.Request()
                .WithUsernamePassword(_options.Value.Email, new NetworkCredential("", _options.Value.Password).SecurePassword)
                .GetAsync();
        }

        public async Task<IChatMembersCollectionPage> ListChatMembers(string id)
        {
            return await Me.Chats[id].Members.Request()
                .WithUsernamePassword(_options.Value.Email, new NetworkCredential("", _options.Value.Password).SecurePassword)
                .GetAsync();
        }

        public async Task<IChatMessagesCollectionPage> ListChatMessages(string id)
        {
            return await Me.Chats[id].Messages.Request()
                .WithUsernamePassword(_options.Value.Email, new NetworkCredential("", _options.Value.Password).SecurePassword)
                .GetAsync();
        }
    }
}