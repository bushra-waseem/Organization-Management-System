using System.Diagnostics;
using Dapper_Company.Models;
using Dapper_Company.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Dapper_Company.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IOrganizationRepository _organizationRepository;

        // ✔ Constructor me repository inject ki
        public HomeController(ILogger<HomeController> logger, IOrganizationRepository organizationRepository)
        {
            _logger = logger;
            _organizationRepository = organizationRepository;
        }

        // ✔ Index page pe organization list bhejna
        public async Task<IActionResult> Index()
        {
            var organizations = await _organizationRepository.GetAllAsync();

            ViewBag.Organizations = organizations;

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult About()
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
