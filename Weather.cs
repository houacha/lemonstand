using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lemonadestand
{
    class Weather
    {
        public string temp;
        public int rngNum;
        public void RandomTemp()
        {
            Random rng = new Random();
            rngNum = rng.Next(0, 101);
        }
    }
}
