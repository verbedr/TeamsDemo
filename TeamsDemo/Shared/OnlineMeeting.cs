using System;

namespace TeamsDemo.Shared
{
    public class OnlineMeeting
    {
        public string Id { get; set; }
        public DateTimeOffset? StartDateTime { get; set; }
        //public MeetingParticipants Participants { get; set; }
        //public LobbyBypassSettings LobbyBypassSettings { get; set; }
        public string JoinUrl { get; set; }
        //public ItemBody JoinInformation { get; set; }
        public bool? IsEntryExitAnnounced { get; set; }
        public bool? IsCancelled { get; set; }
        public bool? IsBroadcast { get; set; }
        public string ExternalId { get; set; }
        public DateTimeOffset? ExpirationDateTime { get; set; }
        public bool? EntryExitAnnouncement { get; set; }
        public DateTimeOffset? EndDateTime { get; set; }
        public DateTimeOffset? CreationDateTime { get; set; }
        public ChatInfo ChatInfo { get; set; }
        //public IEnumerable<MeetingCapabilities> Capabilities { get; set; }
        public DateTimeOffset? CanceledDateTime { get; set; }
        //public AudioConferencing AudioConferencing { get; set; }
        //public OnlineMeetingPresenters? AllowedPresenters { get; set; }
        //public AccessLevel? AccessLevel { get; set; }
        public string Subject { get; set; }
        public string VideoTeleconferenceId { get; set; }
    }
}
