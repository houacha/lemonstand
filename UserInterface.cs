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
                if (Int32.TryParse(input, out result) == false || Convert.ToInt32(input) < 0)
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
        public static void MakeRecipe(Player player)
        {
            player.inventory.AddToRecipe();
            Console.WriteLine("Mix your recipes.");
            for (int i = 0; i < player.inventory.recipeItems.Count; i++)
            {
                Console.WriteLine("How many " + player.inventory.recipeItems[i] + " do you want to in?");
                string recipeAmount = Console.ReadLine();
                int amount = Convert.ToInt32(recipeAmount);
                AddItems(amount, player, i);
            }
            player.recipe.CountItemsInMix();
            RemoveItems(player);
            ConfirmRecipe(player);
        }
        public static void ConfirmRecipe(Player player)
        {
            string response;
            do
            {
                Console.WriteLine("You are going to put " + player.recipe.lemons + ", " + player.recipe.sugarCubes + ", and " + player.recipe.iceCubes + " in your pitcher.");
                Console.WriteLine("Is this how you want your lemonade mix?");
                response = Console.ReadLine();
            } while (response != "yes" && response != "no");
            switch (response)
            {
                case "yes":
                    break;
                case "no":
                    MakeRecipe(player);
                    break;
                default:
                    break;
            }
        }
        public static void AddItems(int loopAmount, Player player, int currentLoop)
        {
            for (int j = 0; j < loopAmount; j++)
            {
                player.recipe.theMix.Add(player.inventory.recipeItems[currentLoop]);
            }
        }
        public static void RemoveItems(Player player)
        {
            for (int i = 0; i < player.recipe.lemons; i++)
            {
                player.inventory.lemons.Remove(player.inventory.allItems[0]);
            }
            for (int j = 0; j < player.recipe.iceCubes; j++)
            {
                player.inventory.iceCubes.Remove(player.inventory.allItems[1]);
            }
            for (int k = 0; k < player.recipe.sugarCubes; k++)
            {
                player.inventory.sugarCubes.Remove(player.inventory.allItems[2]);
            }
        }
    }
}
