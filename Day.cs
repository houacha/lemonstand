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
        public void ShowPlayerCash()
        {
            Console.WriteLine("You have this much money. $" + player1.wallet.cash);
            Console.ReadLine();
        }
        public void RunDay()
        {
            ShowPlayerCash();
            UserInterface.GoToStore(player1.inventory,store,player1);
        }
    }
}
