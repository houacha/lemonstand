using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lemonadestand
{
    class Game
    {
        public void Run()
        {
            Day day = new Day();
            UserInterface.Name(day.player1.name);
            day.RunDay();
        }
    }
}
