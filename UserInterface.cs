using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace lemonadestand
{
    public static class UserInterface
    {
        public static void GoToStore(Inventory item, Store store, Player player)
        {
            string answer = "";
            do
            {
                Console.Clear();
                Console.WriteLine("Would you like to go to the shop?");
                for (int i = 0; i < item.allItems.Count; i++)
                {
                    if (item.allItems[i].amount == 0)
                    {
                        Console.WriteLine("You have no " + item.allItems[i].name + " so you would probably need some if you want to make any money.");
                    }
                    else
                    {
                    }
                }
                answer = Console.ReadLine().ToLower();
                switch (answer)
                {
                    case "yes":
                        store.BuyStuff(player);
                        break;
                    case "no":
                        break;
                    default:
                        break;
                }
            } while (answer != "yes" && answer != "no");
        }
        public static void HowMuch(string item, Item ingredients, Player player, double cost)
        {
            string input = "";
            bool hasLet = false;
            int result;
            do
            {
                Console.Clear();
                Console.WriteLine("How many " + item + " do want?");
                input = Console.ReadLine().ToLower();
                if (Int32.TryParse(input, out result) == false)
                {
                    hasLet = false;
                }
                else
                {
                    hasLet = true;
                }
            } while (hasLet == false);
            ingredients.amount = Convert.ToInt32(input);
            player.CheckCash(ingredients.amount, cost);
        }
        public static void Name(string name)
        {
            Console.WriteLine("What was the name that your mama gave?");
            name = Console.ReadLine();
        }
    }
}
