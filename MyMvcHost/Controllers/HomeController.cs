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
    }
}
