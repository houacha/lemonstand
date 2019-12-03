using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lemonadestand
{
    public class Sugar : Item
    {
        public double sweetness;
        public Sugar(double price, int spoil, int sweetness)
        {
            this.sweetness = sweetness;
            this.price = price;
            spoilage = spoil;
            name = "sugar cubes";
        }
    }
}
