using System.Collections.Generic;

namespace TeamsDemo.Shared
{
    public class Identity
    {
        public string DisplayName { get; set; }
        public string Id { get; set; }
        public IDictionary<string, object> AdditionalData { get; set; }
        public string ODataType { get; set; }

    }
}
