using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ProviderRegister.Models;

namespace ProviderRegister.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View("RegistrationForm");
        }

        [HttpPost]
        public ViewResult RegistrationForm(ProviderInfo providerInfo)
        {
            if (ModelState.IsValid)
            {
                Repository.AddProvider(providerInfo);
                return View("Thanks", providerInfo);
            }
            else
            {
                return View();
            }
        }

        public ViewResult ListRegisteredProviders()
        {
            return View(Repository.Providers);
        }
    }
}
