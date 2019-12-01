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
                Console.WriteLine("You thought it would be a good idea to try and buy less of the items that you put away.");
                Console.ReadLine();
                for (int i = 0; i < player.repromptItems.Count; i++)
                {
                    double cost = player.repromptItems[i].price;
                    UserInterface.HowMuch(player.repromptItems[i].name, player.repromptItems[i], player, cost);
                    if (player.hasEnoughMoney == false)
                    {
                        Console.WriteLine("You thought to yourself that it would be better if you don't have any " + player.repromptItems[i].name + ".");
                        Console.ReadLine();
                        player.repromptItems[i].amount = 0;
                    }
                }
            }
            else
            {
            }
        }
        public void AddItems(Player player)
        {
            player.inventory.AddIce();
            player.inventory.AddCups();
            player.inventory.AddLemons();
            player.inventory.AddSugar();
            for (int i = 0; i < player.inventory.allItems.Count; i++)
            {
                player.inventory.allItems[i].amount = 0;
            }
        }
    }
}
