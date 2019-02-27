using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Policy;
using System.Threading.Tasks;

namespace GameListViewModel
{
    public class GameList
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Platform { get; set; }
        public string RequiredLvl { get; set; }
        public string GameCode { get; set; }
        public string Description { get; set; }
    }

    public class GameLogin
    {
        public string Platform = "Steam";
        public string GameName = "PlayerUnknown's Battlegrounds";
        public string GameExtention = "csgo.exe";
        public string SteamUsername = @"pubgvna_2875";
        public string SteamPassword = @"Pubgvna123123";
    }
    
}