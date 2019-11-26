using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lemonadestand
{
    public class Cups:Item
    {
        public Cups(double price, int spoil)
        {
            this.spoilage = spoil;
            this.price = price;
            name = "red solo cup";
        }
    }
}
