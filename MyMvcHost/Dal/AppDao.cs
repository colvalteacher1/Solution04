
using SharedModelsLib;

namespace MyMvcHost.Dal
{
    public class AppDao
    {
        public static List<Sport> GetSports()
        {
            return new List<Sport>
        {
            new Sport
            {
                Name = "Soccer",
                PlayersPerTeam = 11,
                IsTeamSport = true
            },

            new Sport
            {
                Name = "Tennis",
                PlayersPerTeam = 1,
                IsTeamSport = false
            }
        };
        }

        public static List<Team> GetTeams()
        {
            List<Sport> sports = GetSports();

            return new List<Team>
        {
            // Équipes de soccer
            new Team
            {
                Name = "FC Barcelona",
                Sport = sports[0],
                Players = new List<string>
                {
                    "Lamine Yamal",
                    "Robert Lewandowski",
                    "Pedri",
                    "Frenkie de Jong",
                    "Raphinha"
                }
            },

            new Team
            {
                Name = "Real Madrid",
                Sport = sports[0],
                Players = new List<string>
                {
                    "Kylian Mbappé",
                    "Vinícius Júnior",
                    "Jude Bellingham",
                    "Federico Valverde",
                    "Rodrygo"
                }
            },

            // Joueurs de tennis représentés comme équipes individuelles
            new Team
            {
                Name = "Novak Djokovic",
                Sport = sports[1],
                Players = new List<string>
                {
                    "Novak Djokovic"
                }
            },

            new Team
            {
                Name = "Carlos Alcaraz",
                Sport = sports[1],
                Players = new List<string>
                {
                    "Carlos Alcaraz"
                }
            }
        };
        }
    }
}
