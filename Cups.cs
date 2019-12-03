using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lemonadestand
{
    public class Cups : Item
    {
        public int ounces;
        public Cups(double price, int spoil, int ounces)
        {
            this.ounces = ounces;
            spoilage = spoil;
            this.price = price;
            name = "red solo cup";
        }
    }
}
