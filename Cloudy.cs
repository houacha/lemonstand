using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lemonadestand
{
    public class Cloudy:Weather
    {
        public Cloudy()
        {
            name = "cloudy";
        }
        public override void RandomTemp()
        {
            rngNum = new Random();
            temp = rngNum.Next(45, 75);
        }
    }
}
