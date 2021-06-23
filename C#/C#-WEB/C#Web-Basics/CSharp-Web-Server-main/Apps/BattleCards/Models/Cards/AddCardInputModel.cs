using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleCards.Models.Cards
{
    public class AddCardInputModel
    {
        public string Name { get; set; }
        public string ImageUrl { get; set; }
        public string Keyword { get; set; }
        public int Attack { get; set; }
        public int Health { get; set; }
        public string Description { get; set; }
    }
}
