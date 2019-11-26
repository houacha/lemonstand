using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lemonadestand
{
    public class Ice:Item
    {
        public Ice(double price, int spoil)
        {
            this.price = price;
            this.spoilage = spoil;
            name = "ice cubes";
        }
    }
}
