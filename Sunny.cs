using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lemonadestand
{
    public class Sunny:Weather
    {
        public Sunny()
        {
            name = "sunny";
        }
        public override void RandomTemp(int rng)
        {
            temp = rng;

        }
    }
}
