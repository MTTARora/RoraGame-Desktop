using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoraGame.Models
{
    class Tag
    {
        public string Id { get; set; }
        public string TagName { get; set; }
        public List<Game> games { get; set; }
    }
}
