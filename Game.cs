using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lemonadestand
{
    class Game
    {
        private Random random;
        public Game()
        {
            random = new Random();
        }
        public void Run()
        {
            Day day = new Day(random);
            UserInterface.Welcome();
            UserInterface.Name(day.player1.name);
            day.RunDay();
        }
    }
}
