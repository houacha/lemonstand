using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lemonadestand
{
    public class Store
    {
        public Store()
        {

        }
        public void BuyStuff(Player player)
        {
            for (int i = 0; i < player.inventory.allItems.Count; i++)
            {
                double cost = player.inventory.allItems[i].price;
                UserInterface.HowMuch(player.inventory.allItems[i].name, player.inventory.allItems[i], player, cost);
                if (player.hasEnoughMoney == false)
                {
                    player.repromptItems.Add(player.inventory.allItems[i]);
                }
                else
                {
                }
            }
            if (player.repromptItems.Count > 0)
            {
                for (int i = 0; i < player.repromptItems.Count; i++)
                {
                    double cost = player.inventory.allItems[i].price;
                    UserInterface.HowMuch(player.inventory.allItems[i].name, player.inventory.allItems[i], player, cost);
                    if (player.hasEnoughMoney == false)
                    {
                        Console.WriteLine("You thought to yourself that it would be better if you don't have any " + player.inventory.allItems[i].name + ".");
                        Console.ReadLine();
                    }
                }
            }
            else
            {
            }
        }
    }
}
