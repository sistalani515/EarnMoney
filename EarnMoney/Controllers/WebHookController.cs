using EarnMoney.Models.Requests.WhatsApp;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace EarnMoney.Controllers
{
    public class WebHookController : BaseController
    {
        private readonly ILogger<WebHookController> logger;

        public WebHookController(ILogger<WebHookController> logger)
        {
            this.logger = logger;
        }

        
    }
}
