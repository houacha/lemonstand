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



        // Two places where I think I incorperated S.O.L.I.D.:
        // The first place I can think of is my inventory. I made methods for each individual items to be added to the players inventory,
        // each with their own list to have it added to. By doing this I establish a single responsibily for each method, closed to change but
        // open to adjustments, and maybe the other things (maybe).
        // The second place would most likely be the player class. The player has methods that I think fits single responsibliy but after learning
        // more about S.O.L.I.D. maybe I'm wrong.
    }
}
