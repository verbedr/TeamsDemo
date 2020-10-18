using System.Net.Http;
using Microsoft.Extensions.Http.Logging;
using Microsoft.Extensions.Logging;
using Microsoft.Graph;

namespace TeamsDemo.Server.Plugins
{
    public static class IAuthenticationProviderExtentions
    {
        public static HttpClient CreateGraphClient(this IAuthenticationProvider self, ILogger logger)
        {
            var handlers = GraphClientFactory.CreateDefaultHandlers(self);
            handlers.Add(new LoggingHttpMessageHandler(logger));
            handlers.Add(new InterceptHandler());
            return GraphClientFactory.Create(handlers);
        }
    }
}