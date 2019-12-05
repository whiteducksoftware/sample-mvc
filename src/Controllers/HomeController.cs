using System.Diagnostics;
using System.Reflection;
using System.Runtime.Versioning;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using sample_mvc.Models;

namespace sample_mvc.Controllers
{
    public class HomeController : Controller
    {
        private readonly Settings _settings;

        public HomeController(IOptions<Settings> settings)
        {
            _settings = settings.Value;
        }

        public IActionResult Index()
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

            ViewBag.Title = _settings.Title;

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
