
using System.Diagnostics;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using sutnance.Models;

namespace sutnance.Controllers
{
    [Authorize]
    public class EtatController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
