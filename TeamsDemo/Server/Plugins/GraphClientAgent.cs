﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.Graph;
using Microsoft.Graph.Auth;
using Microsoft.Graph.CallRecords;

namespace TeamsDemo.Server.Plugins
{
    public class GraphClientAgent : GraphServiceClient
    {
        private readonly IOptions<TeamsDemoOption> _options;
        private readonly ILogger<GraphClientAgent> _logger;

        public GraphClientAgent(ClientCredentialProvider authenticationProvider, IOptions<TeamsDemoOption> options, 
            ILogger<GraphClientAgent> logger) 
            : base(authenticationProvider.CreateGraphClient(logger))
        {
            _options = options;
            _logger = logger;
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
                Participants = new MeetingParticipants
                {
                    Organizer = new MeetingParticipantInfo
                    {
                        Identity = new IdentitySet
                        {
                            User = new Identity
                            {
                                Id = _options.Value.UserId
                            }
                        }
                    }
                },
                AccessLevel = AccessLevel.Everyone,
            };
            return await Communications.OnlineMeetings.Request().AddAsync(request);
        }

        public async Task<IList<Chat>> ListChats()
        {
            return await Users[_options.Value.UserId].Chats.Request().GetAsync();
        }

        public async Task<CallRecord> GetCallRecord(string meetNowId)
        {
            return await Communications.CallRecords[meetNowId].Request().GetAsync();
        }

        public async Task SubscribeCallRecords()
        {
            var subscription = new Subscription
            {
                ChangeType = "created",
                NotificationUrl = "https://TeamsDemoServer20201020142433.azurewebsites.net/webhook",
                Resource = "communications/callRecords",
                ExpirationDateTime = DateTimeOffset.Now.AddHours(1),
                ClientState = "secretClientValue",
                LatestSupportedTlsVersion = "v1_2"
            };
            await Subscriptions.Request().AddAsync(subscription);
        }
    }
}