using System;
using System.Collections.Generic;
using System.Text;

namespace SharedModelsLib
{
    public class Team
    {
        public string Name { get; set; }

        public Sport Sport { get; set; }

        public List<string> Players { get; set; } = new List<string>();
    }
}
