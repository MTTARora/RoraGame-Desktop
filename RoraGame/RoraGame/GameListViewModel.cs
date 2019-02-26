using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoraGame
{
    class GameListViewModel
    {
        public string Platform { get; set; }
        public string GameName { get; set; }
        public string GameExtention { get; set; }
        public string SteamUsername { get; set; }
        public string SteamPassword { get; set; }
    }

    class Game
    {
        public int No { get; set; }
        public string Name { get; set; }
        public string Platform { get; set; }
        public string RequiredLvl { get; set; }
        public string Description { get; set; }
    }
}
