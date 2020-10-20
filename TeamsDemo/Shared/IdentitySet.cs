using System.Collections.Generic;

namespace TeamsDemo.Shared
{
    public class IdentitySet
    {
        public Identity Application { get; set; }
        public Identity Device { get; set; }
        public Identity User { get; set; }
        public IDictionary<string, object> AdditionalData { get; set; }
        public string ODataType { get; set; }
    }
}
