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
        }
    }
}
