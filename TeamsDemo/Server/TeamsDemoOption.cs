using System.Security;

namespace TeamsDemo.Server
{
    public class TeamsDemoOption
    {
        public string UserId { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string ClientId { get; set; }
        public string ClientSecret { get; set; }
        public string TenantId { get; set; }
    }
}
