using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace TeamsDemo.Server.Plugins
{
    public class InterceptHandler : DelegatingHandler
    {
        protected async override Task<HttpResponseMessage> SendAsync(HttpRequestMessage httpRequest, CancellationToken cancellationToken)
        {
            var response = await base.SendAsync(httpRequest, cancellationToken);
            if (response.IsSuccessStatusCode) return response;

            return response;
        }
    }
}