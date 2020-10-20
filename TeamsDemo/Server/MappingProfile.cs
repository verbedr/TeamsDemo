using AutoMapper;

namespace TeamsDemo.Server
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Microsoft.Graph.OnlineMeeting, Shared.OnlineMeeting>();
            CreateMap<Microsoft.Graph.ChatInfo, Shared.ChatInfo>();

            CreateMap<Microsoft.Graph.Chat, Shared.Chat>();
            CreateMap<Microsoft.Graph.ConversationMember, Shared.ConversationMember>();
            CreateMap<Microsoft.Graph.ChatMessage, Shared.ChatMessage>();
            CreateMap<Microsoft.Graph.CallRecords.CallRecord, Shared.CallRecord>();
            CreateMap<Microsoft.Graph.Identity, Shared.Identity>();
            CreateMap<Microsoft.Graph.IdentitySet, Shared.IdentitySet>();
            CreateMap<Microsoft.Graph.ItemBody, Shared.ItemBody>();
        }
    }
}
