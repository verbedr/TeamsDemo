using System.Collections.Generic;

namespace TeamsDemo.Shared
{
    public class ItemBody
    {
        public string Content { get; set; }
        //public BodyType? ContentType { get; set; }
        public IDictionary<string, object> AdditionalData { get; set; }
        public string ODataType { get; set; }
    }
}
