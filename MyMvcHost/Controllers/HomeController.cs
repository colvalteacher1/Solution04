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

        public IActionResult FilterTeams(int minPlayers = 0)
        {
            List<Player> players = AppDao.GetPlayers();
            Debug.WriteLine("Action exécutée");
       
            List<TeamResult> filteredTeams = players
                .GroupBy(p => p.TeamName)
                .Select(g => new TeamResult
                {
                    Name = g.Key,
                    PlayerCount = g.Count()
                })
                .Where(t => t.PlayerCount >= minPlayers)
                .OrderByDescending(t => t.PlayerCount)
                .ToList();

            return View(filteredTeams);   
        }

        public IActionResult GetPlayersStartWith()
        {
            return View();
        }
    }
}
