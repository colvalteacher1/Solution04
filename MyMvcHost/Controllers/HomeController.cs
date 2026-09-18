using Microsoft.AspNetCore.Mvc;
using MyMvcHost.Dal;
using SharedModelsLib;
using System.Diagnostics;
using System.Text.Json;

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

        public IActionResult GetPlayers(string teamName)
        {
            if (teamName != null)
            {
                List<Player> selectedPlayers = AppDao.GetPlayers().Where(p => p.TeamName == teamName).ToList();
                return View(selectedPlayers);
            }

            return RedirectToAction("index");
        }

        [HttpGet]
        public IActionResult AddPlayer(string joueur)
        {
            Player? player = JsonSerializer.Deserialize<Player>(joueur);
            AppDao.players.Add(player);
            return RedirectToAction("index");
        }
    }
    }
