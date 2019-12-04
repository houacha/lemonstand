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
        public Player player;
        public Store store;
        public Weather weather;
        public Game()
        {
            random = new Random();
            player = new Player();
            store = new Store();
            weather = new Weather();
        }
        public void Run()
        {
            Day day = new Day(random, player, store, weather);
            UserInterface.Welcome();
            UserInterface.Name(player.name);
            day.RunDay();
        }
    }
}
