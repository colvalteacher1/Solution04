using Microsoft.AspNetCore.Mvc;
using MyMvcHost.Dal;
using SharedModelsLib;
using System.Diagnostics;

namespace MyMvcHost.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            List<Sport> sports = AppDao.GetSports();
            return View(sports);
        }

        public IActionResult GetTeams(string sportName)
        { 
            if (sportName != null)
            {
               List<Team> selectedTeams = AppDao.GetTeams().Where(t => t.Sport.Name == sportName).ToList();
                return View(selectedTeams);
            }

            return RedirectToAction("index");

            


        }
    }
}
