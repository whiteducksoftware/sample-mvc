using FredApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using System;

namespace FredApi.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class FredTextController : ControllerBase
    {
        private IConfiguration _configuration;
        private readonly Settings _settings;
        public FredTextController(IOptions<Settings> settings, IConfiguration iconfig)
        {
            _settings = settings.Value;
            _configuration = iconfig;
        }

        [HttpGet]
        public ContentResult Get()
        {
            return Content(_settings.Value);
        }
    }
}
