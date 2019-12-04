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
                int amount = UserInterface.HowMuch(player.inventory.allItems[i]);
                player.CheckCash(amount, cost);
                if (player.hasEnoughMoney == false)
                {
                    repromptItems.Add(player.inventory.allItems[i]);
                }
                else
                {
                    switch (player.inventory.allItems[i].name)
                    {
                        case "lemons":
                            player.inventory.AddLemons(amount);
                            break;
                        case "ice cubes":
                            player.inventory.AddIce(amount);
                            break;
                        case "sugar cubes":
                            player.inventory.AddSugar(amount);
                            break;
                        case "red solo cup":
                            player.inventory.AddCups(amount);
                            break;
                        default:
                            break;
                    }
                }
            }
            if (repromptItems.Count > 0)
            {
                Console.WriteLine("You thought it would be a good idea to try and buy less of the items that you put away.");
                Console.ReadLine();
                for (int i = 0; i < repromptItems.Count; i++)
                {
                    double cost = repromptItems[i].price;
                    int amount = UserInterface.HowMuch(repromptItems[i]);
                    player.CheckCash(amount, cost);
                    if (player.hasEnoughMoney == false)
                    {
                        Console.WriteLine("You thought to yourself that it would be better if you don't have any " + repromptItems[i].name + ".");
                        Console.ReadLine();
                    }
                    else
                    {
                        switch (repromptItems[i].name)
                        {
                            case "lemons":
                                player.inventory.AddLemons(amount);
                                break;
                            case "ice cubes":
                                player.inventory.AddIce(amount);
                                break;
                            case "sugar cubes":
                                player.inventory.AddSugar(amount);
                                break;
                            case "red solo cup":
                                player.inventory.AddCups(amount);
                                break;
                            default:
                                break;
                        }
                    }
                }
                repromptItems.Clear();
            }
        }
    }
}
