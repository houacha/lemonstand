using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lemonadestand
{
    public class Player
    {
        public string name;
        public Inventory inventory = new Inventory();
        public Wallet wallet = new Wallet();
        public Pitcher pitcher = new Pitcher();
        public Recipe recipe = new Recipe();
        public bool hasEnoughMoney = true;
        public List<Item> repromptItems = new List<Item> { };
        public void CheckCash(int amount, double cost)
        {
            double totalCost = amount * cost;
            if ((wallet.cash - totalCost) < 0)
            {
                Console.WriteLine("You do not have enough money for this. Buy less or none at all you deadbeat.");
                hasEnoughMoney = false;
            }
            else
            {
                hasEnoughMoney = true;
                wallet.cash -= totalCost;
                Console.WriteLine("$"+wallet.cash);
                Console.ReadLine();
            }
        }
        public Player()
        {
            wallet.cash = 10.00;
        }
    }
}
