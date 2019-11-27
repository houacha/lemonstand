using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lemonadestand
{
    public class Lemon:Item
    {
        public int sourness;
        public Lemon(double price, int spoil, int sour)
        {
            sourness = sour;
            this.price = price;
            spoilage = spoil;
            name = "lemons";
        }
    }
}
