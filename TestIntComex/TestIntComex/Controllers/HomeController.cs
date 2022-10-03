using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using TestIntComex.Core.DTOs;
using TestIntComex.Core.Entities;
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

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            if (!await _informationContact.IsFullContactType()) 
            { 
                ResultsDto fillCT = await _informationContact.FillContactType();
                if (!fillCT.IsSuccess)
                    return View("Error");
            }
                
            ViewBag.ContactsType = await _informationContact.ListContactsType();

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SaveContact(TbContact tbContact)
        {
            ResultsDto result = await _informationContact.SaveInformation(tbContact);
            if (!result.IsSuccess)
                return View("Error");

            ViewBag.ContactsType = await _informationContact.ListContactsType();
            return View("Index");
        }

        [HttpGet]
        public async Task<IActionResult> GetDataContact()
        {
            return Json(await _informationContact.ListContacts());
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}