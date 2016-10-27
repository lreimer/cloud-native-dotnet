using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace QAware.OSS.Controllers
{
    [Route("admin/[controller]")]
    public class InfoController : Controller
    {
        private IConfigurationRoot configuration;
        public InfoController(IConfigurationRoot configuration)
        {
            this.configuration = configuration;
        }

        [HttpGet]
        public virtual IActionResult Get()
        {
            return this.Ok(configuration["message"]);
        }
    }
}