using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lemonadestand
{
    public class Ice : Item
    {
        public int coldness;
        public Ice(double price, int spoil, int cold)
        {
            coldness = cold;
            this.price = price;
            spoilage = spoil;
            name = "ice cubes";
        }
    }
}
