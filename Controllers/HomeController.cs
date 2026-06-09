using System.Diagnostics;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using sutnance.Models;

namespace sutnance.Controllers
{
    [Authorize]
    public class HomeController(sutnance.Data.sutnanceContext dbContext) : Controller
    {
        public IActionResult Index()
        {
            var latestReportsPerMachine = dbContext.Reports
                .Where(r => r.CreationTime ==
                            dbContext.Reports
                                .Where(x => x.MachineId == r.MachineId)
                                .Max(x => x.CreationTime))
                .GroupBy(r => r.State)
                .ToDictionary(g => g.Key, g => g.Count());
            ViewBag.Dashboard = new Dashboard()
            {
                TotalMachines =  dbContext.Machines.Count(),
                StableMachines = latestReportsPerMachine.GetValueOrDefault(MachineState.Stable),
                CriticalMachines = latestReportsPerMachine.GetValueOrDefault(MachineState.Critique),
                UndocumentedMachines = latestReportsPerMachine.GetValueOrDefault(MachineState.RetabliUndocumente)
            };
            return View();
        }
    }
}
