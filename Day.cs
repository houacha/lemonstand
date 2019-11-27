using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lemonadestand
{
    class Day
    {
        public Player player1 = new Player();
        public Store store = new Store();
        public void RunDay()
        {
            player1.ShowPlayerCash();
            UserInterface.GoToStore(player1.inventory,store,player1);
            store.AddItems(player1);
            player1.CheckInventory();
        }
    }
}
