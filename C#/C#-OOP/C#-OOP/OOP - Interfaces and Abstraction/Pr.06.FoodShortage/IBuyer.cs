using System;
using System.Collections.Generic;
using System.Text;

namespace Pr._06.FoodShortage
{
    public interface IBuyer
    {
        public void BuyFood();
        public int Food { get; set; }
    }
}
