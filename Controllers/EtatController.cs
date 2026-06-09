
using System.Diagnostics;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using sutnance.Models;

namespace sutnance.Controllers
{
    [Authorize]
    [Route("[controller]")]
    public class EtatController(MachineManager machineManager) : Controller
    {
        [HttpGet]
        /*[Route("{page:int?}")]*/
        public async Task<IActionResult> Index(string? search,MachineState? state,int page=0)
        {
            ViewBag.machines = await machineManager.Get(search, state, page);
            return View();
        }
[Route("Create")]
        [HttpPost]
        public async Task<IActionResult> Create(string name,string type,string ip,string site,DateTime bootTime)
        {
            await machineManager.Create(name, type, ip, site,bootTime);
            return RedirectToAction(nameof(Index));
        }
    }
}
