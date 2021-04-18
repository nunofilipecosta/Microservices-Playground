using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

using SampleService.Services;

namespace SampleService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CoinsMarketController : ControllerBase
    {
        private readonly ILogger<CoinsMarketController> logger;
        private readonly IApiClient apiClient;

        public CoinsMarketController(ILogger<CoinsMarketController> logger, IApiClient apiClient)
        {
            this.logger = logger;
            this.apiClient = apiClient;
        }

        [HttpGet]
        [Route("currency")]
        public IActionResult Get(string currency)
        {
            var result = apiClient.ConnectToApi(currency);

            return Ok(result);
        }
    }
}
