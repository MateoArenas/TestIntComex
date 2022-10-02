using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using TestIntComex.Core.Interfaces;
using TestIntComex.Models;

namespace TestIntComex.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IInformationContactRepository _informationContact;

        public HomeController(ILogger<HomeController> logger, IInformationContactRepository informationContact)
        {
            _logger = logger;
            _informationContact = informationContact;
        }

        public async Task<IActionResult> Index()
        {
            if (await _informationContact.IsFullContactType())
                await _informationContact.FillContactType();

            ViewBag.ContactsType = await _informationContact.ListContactsType();

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