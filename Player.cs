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
        public void ShowPlayerCash()
        {
            Console.WriteLine("You have this much money. $" + wallet.cash);
            Console.ReadLine();
        }
        public void CheckCash(int amount, double cost)
        {
            double totalCost = amount * cost;
            if ((wallet.cash - totalCost) < 0)
            {
                Console.WriteLine("You do not have enough money for this. Buy less or none at all you deadbeat.");
                Console.ReadLine();
                hasEnoughMoney = false;
            }
            else
            {
                hasEnoughMoney = true;
                wallet.cash -= totalCost;
                Console.WriteLine("You have $" + wallet.cash + " left.");
                Console.ReadLine();
            }
        }
        public void CheckInventory()
        {
            Console.WriteLine("You currently have:" + "\n" + inventory.iceCubes.Count + " " + inventory.allItems[1].name);
            Console.WriteLine(inventory.lemons.Count + " " + inventory.allItems[0].name);
            Console.WriteLine(inventory.sugarCubes.Count + " " + inventory.allItems[2].name);
            Console.WriteLine(inventory.cups.Count + " " + inventory.allItems[3].name);
            Console.ReadLine();
        }
        public void CheckSpoil()
        {
            if (inventory.iceCubes.Count > 0)
            {
                for (int i = 0; i < inventory.iceCubes.Count; i++)
                {
                    inventory.iceCubes[i].Spoiled(inventory.iceCubes[i], inventory.iceCubes);
                }
                Console.WriteLine("While looking through your cooler you realized that " + inventory.iceCubes.Count + " has faded to the aether.");
            }
            if (inventory.lemons.Count > 0)
            {
                for (int l = 0; l < inventory.lemons.Count; l++)
                {
                    inventory.lemons[l].Spoiled(inventory.lemons[l], inventory.lemons);
                }
                Console.WriteLine("When you were counting your lemons, you were startled by the fact that " + inventory.lemons.Count + " sprouted legs and ran off into the sunset.");
            }
            Console.ReadLine();
        }
        public Player()
        {
            wallet.cash = 10.00;
        }
    }
}
