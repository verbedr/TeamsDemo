using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Logging;
using System.IO;
using System.Threading.Tasks;
using TeamsDemo.Server.Plugins;

namespace TeamsDemo.Server.Controllers
{
    [ApiController]
    [Route("webhook")]
    public class WebhookController : ControllerBase
    {
        private readonly ILogger<ClientController> _logger;
        private readonly IHubContext<SubscriptionHub> _hub;

        public WebhookController(ILogger<ClientController> logger, IHubContext<SubscriptionHub> hub)
        {
            _logger = logger;
            _hub = hub;
        }

        [HttpPost()]
        public async Task Create()
        {
            Request.Body.Seek(0, System.IO.SeekOrigin.Begin);
            using var reader = new StreamReader(Request.Body);
            var content = reader.ReadToEnd();
            await _hub.Clients.All.SendAsync("handle", content);
        }

        [HttpPost("?validationToken={validationToken}")]
        public ActionResult Create(string validationToken)
        {
            _logger.LogInformation("success with {validationToken}", validationToken);
            return Ok("secretClientValue");
        }
    }
}
