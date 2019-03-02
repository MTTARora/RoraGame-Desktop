using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoraGame.Models
{
    class News
    {

        public static List<Games> getNews()
        {
            List<Games> items = new List<Games>();
            items.Add(new Games() { Dates = "29/12/1999", Name = "Assassin's Creed", RequiredLvl = "Level 6", Description = "https://www.assassinscreed.com" });
            items.Add(new Games() { Dates = "29/12/1999", Name = "Call Of Duty", RequiredLvl = "Level 6", Description = "https://www.assassinscreed.com" });
            items.Add(new Games() { Dates = "29/12/1999", Name = "Fornite", RequiredLvl = "Level 6", Description = "https://www.assassinscreed.com" });
            items.Add(new Games() { Dates = "29/12/1999", Name = "Battlefield", RequiredLvl = "Level 6", Description = "qweqwádfádf ăè ăè adfăè ăe ăè " });
            items.Add(new Games() { Dates = "29/12/1999", Name = "Dota", RequiredLvl = "Level 6", Description = "qweqwádfádf ăè ăè adfăè ăe ăè " });
            items.Add(new Games() { Dates = "29/12/1999", Name = "Counter-Strike : Global Offensive", RequiredLvl = "Level 6", Description = "qweqwádfádf ăè ăè adfăè ăe ăè " });

            return items;
        }
    }
}
