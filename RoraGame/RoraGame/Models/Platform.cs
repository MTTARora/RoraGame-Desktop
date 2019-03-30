using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoraGame.Models
{
    class Platform
    {
        public string PlatformId { get; set; }
        public string PlatformName { get; set; }
        public string imageLoginPlatform { get; set; }
        public string imageRememberPlatform { get; set; }
        public List<Game> games { get; set; }
    }
}
