using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using System.Diagnostics;

namespace Cassini.Core.WebClient.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [Authorize]
        public async Task<IActionResult> About()
        {
            await WriteOutIdentityInformation();
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View();
        }

        public async Task WriteOutIdentityInformation()
        {
            var identityToken = await HttpContext.Authentication.GetAuthenticateInfoAsync("DefaultScheme");

            Debug.WriteLine($"identityToken:{identityToken}");

            foreach(var claim in User.Claims)
            {
                Debug.WriteLine($"ClainType:{claim.Type}");
            }
        }
    }
}
