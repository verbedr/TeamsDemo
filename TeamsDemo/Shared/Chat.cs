using System;
using System.Collections.Generic;

namespace TeamsDemo.Shared
{
    public class Chat
    {
        public string Id { get; set; }
        public DateTimeOffset? CreatedDateTime { get; set; }
        public DateTimeOffset? LastUpdatedDateTime { get; set; }
        public string Topic { get; set; }
        //public IChatInstalledAppsCollectionPage InstalledApps { get; set; }
        public IEnumerable<ConversationMember> Members { get; set; }
        public IEnumerable<ChatMessage> Messages { get; set; }
    }
}
