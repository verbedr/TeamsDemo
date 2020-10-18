using System.Collections.Generic;

namespace TeamsDemo.Shared
{
    public class ChatInfo
    {
        public string MessageId { get; set; }
        public string ReplyChainMessageId { get; set; }
        public string ThreadId { get; set; }
        public IDictionary<string, object> AdditionalData { get; set; }
        public string ODataType { get; set; }
    }
}
