using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lemonadestand
{
    public class Store
    {
        public List<Item> repromptItems;
        public Store()
        {
            repromptItems = new List<Item> { };
        }
        public void BuyStuff(Player player)
        {
            for (int i = 0; i < player.inventory.allItems.Count; i++)
            {
                double cost = player.inventory.allItems[i].price;
                UserInterface.HowMuch(player.inventory.allItems[i].name, player.inventory.allItems[i]);
                player.CheckCash(player.inventory.allItems[i].amount, cost);
                if (player.hasEnoughMoney == false)
                {
                    repromptItems.Add(player.inventory.allItems[i]);
                }
                else
                {
                }
            }
            if (repromptItems.Count > 0)
            {
                Console.WriteLine("You thought it would be a good idea to try and buy less of the items that you put away.");
                Console.ReadLine();
                for (int i = 0; i < repromptItems.Count; i++)
                {
                    double cost = repromptItems[i].price;
                    UserInterface.HowMuch(repromptItems[i].name, repromptItems[i]);
                    player.CheckCash(repromptItems[i].amount, cost);
                    if (player.hasEnoughMoney == false)
                    {
                        Console.WriteLine("You thought to yourself that it would be better if you don't have any " + repromptItems[i].name + ".");
                        Console.ReadLine();
                        repromptItems[i].amount = 0;
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
