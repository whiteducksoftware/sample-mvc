using System.Diagnostics;
using System.Net.Http;
using System.Reflection;
using System.Runtime.Versioning;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using sample_mvc.Models;

namespace sample_mvc.Controllers
{
    public class HomeController : Controller
    {
        private readonly Settings _settings;
        private readonly IHttpClientFactory _clientFactory;

        public HomeController(IOptions<Settings> settings, IHttpClientFactory clientFactory)
        {
            _settings = settings.Value;
            _clientFactory = clientFactory;
        }

        public async Task<IActionResult> Index()
        {
            var framework = Assembly
                .GetEntryAssembly()?
                .GetCustomAttribute<TargetFrameworkAttribute>()?
                .FrameworkName;

            ViewBag.Platform = new
            {
                OsVersion = System.Runtime.InteropServices.RuntimeInformation.OSDescription,
                DotnetCoreVersion = framework
            };

            try
            {
                var httpResponse = await _clientFactory.CreateClient()
               .GetAsync($"{_settings.TextUrl}");

                if (httpResponse.IsSuccessStatusCode)
                {
                    var content = await httpResponse.Content.ReadAsStringAsync();

                    ViewBag.Title = content;
                }
            }
            catch (System.Exception)
            {
               ViewBag.Title = _settings.Title;
            }
                
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
