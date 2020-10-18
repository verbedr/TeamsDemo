using System.Collections.Generic;

namespace TeamsDemo.Shared
{
    public class ConversationMember
    {
        public string DisplayName { get; set; }
        public IEnumerable<string> Roles { get; set; }
    }
}
