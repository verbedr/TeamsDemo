using System;

namespace TeamsDemo.Shared
{
    public class ChatMessage
    {
        public string WebUrl { get; set; }
        public string Summary { get; set; }
        public string Subject { get; set; }
        public string ReplyToId { get; set; }
        //public IEnumerable<ChatMessageReaction> Reactions { get; set; }
        //public ChatMessagePolicyViolation PolicyViolation { get; set; }
        //public ChatMessageType? MessageType { get; set; }
        //public IEnumerable<ChatMessageMention> Mentions { get; set; }
        public string Locale { get; set; }
        //public IChatMessageHostedContentsCollectionPage HostedContents { get; set; }
        public DateTimeOffset? LastModifiedDateTime { get; set; }
        //public ChatMessageImportance? Importance { get; set; }
        public IdentitySet From { get; set; }
        public string Etag { get; set; }
        public DateTimeOffset? DeletedDateTime { get; set; }
        public DateTimeOffset? CreatedDateTime { get; set; }
        public string ChatId { get; set; }
        //public ChannelIdentity ChannelIdentity { get; set; }
        public ItemBody Body { get; set; }
        //public IEnumerable<ChatMessageAttachment> Attachments { get; set; }
        public DateTimeOffset? LastEditedDateTime { get; set; }
        //public IChatMessageRepliesCollectionPage Replies { get; set; }

    }
}
