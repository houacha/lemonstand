using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace lemonadestand
{
    public static class UserInterface
    {
        public static void CupCharge(Player player)
        {
            string input;
            do
            {
                Console.Clear();
                Console.WriteLine("What do you want to charge people?");
                input = Console.ReadLine();
            } while (Double.TryParse(input, out double result) == false);
            player.pitcher.pricePerCup = Convert.ToDouble(input);
            if (Convert.ToDouble(input) < 0)
            {
                Console.WriteLine("Your amazing characteristics as a human being has made you decide to give your special lemonade away for free. Not only that but you are also giving away your money. Maybe as compensation for your shit lemonade.");
                Console.ReadLine();
            }
        }
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
                Console.WriteLine("The price of " + item + " is $" + ingredients.price);
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
            Console.WriteLine("What is the name that your mama gave you?");
            name = Console.ReadLine();
        }
        public static void PromptWaterAmount(Player player)
        {
            string water;
            do
            {
            Console.WriteLine("How many cups water would you like to add? Enter a POSITIVE, WHOLE number. If number is less than 4, default will be 4. Can't make lemonade without water.");
            water = Console.ReadLine();
            } while (Int32.TryParse(water, out int result) == false || Convert.ToInt32(water) < 0);
            player.recipe.water = Convert.ToInt32(water);
        }
        public static int PromptMixAmount(string loop)
        {
            string recipeAmount;
            do
            {
                Console.WriteLine("How many " + loop + " do you want to put in?");
                recipeAmount = Console.ReadLine();
            } while (Int32.TryParse(recipeAmount, out int result) == false || Convert.ToInt32(recipeAmount) < 0);
            int amount = Convert.ToInt32(recipeAmount);
            Console.Clear();
            return amount;
        }
        public static void MakeRecipe(Player player)
        {
            player.recipe.lemons = 0;
            player.recipe.iceCubes = 0;
            player.recipe.sugarCubes = 0;
            player.inventory.AddToRecipe();
            Console.WriteLine("Mix your recipe.");
            for (int i = 0; i < player.inventory.recipeItems.Count; i++)
            {
                if (player.inventory.recipeItems[i] == "lemon")
                {
                    int lemons;
                    do
                    {
                        lemons = PromptMixAmount(player.inventory.recipeItems[i]);
                        if (lemons > player.inventory.lemons.Count)
                        {
                            Console.WriteLine("You can't add more items than what you have.");
                            Console.ReadLine();
                        }
                    } while (lemons > player.inventory.lemons.Count);
                    AddItems(lemons, player, i);
                    Console.Clear();
                }
                else if (player.inventory.recipeItems[i] == "ice")
                {
                    int ice;
                    do
                    {
                        ice = PromptMixAmount(player.inventory.recipeItems[i]);
                        if (ice > player.inventory.iceCubes.Count)
                        {
                            Console.WriteLine("You can't add more items than what you have.");
                            Console.ReadLine();
                        }
                    } while (ice > player.inventory.iceCubes.Count);
                    AddItems(ice, player, i);
                    Console.Clear();
                }
                else if (player.inventory.recipeItems[i] == "sugar")
                {
                    int sugar;
                    do
                    {
                        sugar = PromptMixAmount(player.inventory.recipeItems[i]);
                        if (sugar > player.inventory.sugarCubes.Count)
                        {
                            Console.WriteLine("You can't add more items than what you have.");
                            Console.ReadLine();
                        }
                    } while (sugar > player.inventory.sugarCubes.Count);
                    AddItems(sugar, player, i);
                    Console.Clear();
                }
            }
        }
        public static string ConfirmRecipe(Player player)
        {
            string response;
            player.recipe.CountItemsInMix();
            do
            {
                Console.Clear();
                Console.WriteLine("You are going to put " + player.recipe.lemons + " lemons, " + player.recipe.sugarCubes + " sugar cubes, and " + player.recipe.iceCubes + " ice cubes into your pitcher.");
                Console.WriteLine("Is this how you want your lemonade mix?");
                response = Console.ReadLine();
            } while (response != "yes" && response != "no");
            switch (response)
            {
                case "yes":
                    RemoveItems(player);
                    CupCharge(player);
                    player.pitcher.DetermineSweetness(player);
                    player.pitcher.DetermineColdness(player);
                    break;
                case "no":
                    for (int i = 0; i <= player.recipe.theMix.Count; i++)
                    {
                        player.recipe.theMix.RemoveAt(0);
                        i = 0;
                    }
                    for (int j = 0; j <= player.inventory.recipeItems.Count; j++)
                    {
                        player.inventory.recipeItems.RemoveAt(0);
                        j = 0;
                    }
                    MakeRecipe(player);
                    break;
                default:
                    break;
            }
            return response;
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
