using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoraGame.Models
{
    class GameAccount
    {
        public string Id { get; set; }
        public string userName { get; set; }
        public string passwords { get; set; }
        public string passworde { get; set; }
        public string passwordf { get; set; }
        public string email { get; set; }
        public bool available { get; set; }
        public string bannedDate { get; set; }
        public string bannedEndDate { get; set; }
        public string desc { get; set; }
        public List<Game> games { get; set; }
    }
}
