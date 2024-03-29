﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace lemonadestand
{
    public static class UserInterface
    {
        public static int GameMenu(List<string> options)
        {
            string response;
            int result;
            do
            {
                Console.Clear();
                Console.WriteLine("Choose an option to determine what to do (enter one of the numbers):");
                for (int i = 0; i < options.Count; i++)
                {
                    Console.WriteLine((i + 1) + ")" + options[i]);
                }
                response = Console.ReadLine();
            } while (Int32.TryParse(response, out result) == false || result > options.Count || result <= 0);
            return result;
        }
        public static void CupCharge(Player player)
        {
            string input;
            do
            {
                Console.Clear();
                Console.WriteLine("What do you want to charge people?");
                input = Console.ReadLine();
            } while (Double.TryParse(input, out double result) == false || result < 0);
            player.pitcher.pricePerCup = Convert.ToDouble(input);
            if (Convert.ToDouble(input) < 0)
            {
                Console.WriteLine("Your amazing characteristics as a human being has made you decide to give your special lemonade away for free. Not only that but you are also giving away your money. Maybe as compensation for your shit lemonade.");
                Console.ReadLine();
            }
        }
        public static void GoToStore(Inventory item, Store store, Player player)
        {
            string answer;
            do
            {
                Console.Clear();
                Console.WriteLine("Would you like to go to the shop?");
                for (int i = 0; i < item.allItems.Count; i++)
                {
                    if (item.iceCubes.Count == 0 && item.sugarCubes.Count == 0 && item.cups.Count == 0 && item.lemons.Count == 0)
                    {
                        Console.WriteLine("You have no " + item.allItems[i].name + " so you would probably need some if you want to make any money.");
                    }
                    else if (item.iceCubes.Count == 0)
                    {
                        Console.WriteLine("You have no more ice.");
                    }
                    else if (item.sugarCubes.Count == 0)
                    {
                        Console.WriteLine("You have no sugarcubes.");
                    }
                    else if (item.cups.Count == 0)
                    {
                        Console.WriteLine("You're out of cups.");
                    }
                    else if (item.lemons.Count == 0)
                    {
                        Console.WriteLine("No lemons left in your pouch.");
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
        public static void Name(string yourName)
        {
            Console.Clear();
            Console.WriteLine("What is the name that your mama gave you?");
            yourName = Console.ReadLine();
        }
        public static void PromptWaterAmount(Player player)
        {
            string water;
            do
            {
                Console.Clear();
                Console.WriteLine("How many cups water would you like to add? Enter a POSITIVE, WHOLE number. If number is less than 4, default will be 4. Can't make lemonade without water.");
                water = Console.ReadLine();
            } while (Int32.TryParse(water, out int result) == false);
            if (Convert.ToInt32(water) < 4)
            {
                player.recipe.water = 4;
            }
            else
            {
                player.recipe.water = Convert.ToInt32(water);
            }
            ConfirmWater(player);
        }
        public static void ConfirmWater(Player player)
        {
            string response;
            do
            {
                Console.Clear();
                Console.WriteLine("Are you sure you want to add " + player.recipe.water + " cups of water?");
                response = Console.ReadLine().ToLower();
            } while (response != "yes" && response != "no");
            switch (response)
            {
                case "yes":
                    break;
                case "no":
                    player.recipe.water = 0;
                    PromptWaterAmount(player);
                    break;
                default:
                    break;
            }
        }
        public static int PromptMixAmount(string loop)
        {
            string recipeAmount;
            do
            {
                Console.Clear();
                Console.WriteLine("How many " + loop + " do you want to put in?");
                recipeAmount = Console.ReadLine();
            } while (Int32.TryParse(recipeAmount, out int result) == false || result < 0);
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
            Console.WriteLine("Mix your recipe for one pitcher.");
            Console.ReadLine();
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
                    player.AddItems(lemons, player, i);
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
                    player.AddItems(ice, player, i);
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
                    player.AddItems(sugar, player, i);
                    Console.Clear();
                }
            }
            player.inventory.recipeItems.Clear();
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
                response = Console.ReadLine().ToLower();
            } while (response != "yes" && response != "no");
            return response;
        }
        public static int HowMuch(Item items)
        {
            string input;
            do
            {
                Console.Clear();
                Console.WriteLine("The price of " + items.name + " is $" + items.price);
                Console.WriteLine("How many " + items.name + " do want?");
                input = Console.ReadLine().ToLower();
            } while (Int32.TryParse(input, out int result) == false || result < 0);
            return Convert.ToInt32(input);
        }
        public static int DaysOfPlaying()
        {
            Console.Clear();
            Console.WriteLine("Maybe playing this game this long wasn't the brightest idea, so how about I let you decide how long you want to play for.");
            string days = Console.ReadLine();
            do
            {
                Console.Clear();
                Console.WriteLine("Please for the love of coding, just enter a positive number.");
            } while (Int32.TryParse(days, out int result) == false || result < 0);
            return Convert.ToInt32(Console.ReadLine());
        }
        public static double GoalToReach()
        {
            int goal = 0;
            string response;
            do
            {
                Console.Clear();
                Console.WriteLine("Well kid, welcome to the world of capitalism where dreams are made by crushing the lives of others.\nI'm both excited and sad for you as now you can experience all the hardships of life.\nNo more playing in the sandbox, time to get up and shine.\nWith that being said;\nSet a goal for the amount of money you want to make.");
                Console.Write("$");
                response = Console.ReadLine();
            } while (Int32.TryParse(response, out int result) == false || result < 0);
            goal = Convert.ToInt32(response);
            return goal;
        }
        public static bool OutOfCups(Player player)
        {
            bool cupsOut = false;
            if (player.inventory.cups.Count == 0)
            {
                Console.WriteLine("Looks like you're out of cups. Don't really see what more you can do soooooo......");
                Console.ReadLine();
                cupsOut = true;
            }
            return cupsOut;
        }
        public static string OutOfLemonade(Player player)
        {
            string response = "";
            if (player.pitcher.lemonadeLeft == 0)
            {
                do
                {
                    Console.Clear();
                    Console.WriteLine("You are out of your special lemonade. Would you perhaps like to make more?");
                    response = Console.ReadLine().ToLower();
                } while (response != "yes" && response != "no");
            }
            return response;
        }
        public static void Welcome()
        {
            Console.WriteLine("Welcome to your very own lemonade start-up business.\n\nYou're playing as a child who has a frivolous spending habit for games in hopes of becoming a pro gamer.\nPay to win is your life motto.\nYour parents are extremely tire of supporting your idiotic dreams.\nThey have told you that they are no longer giving you an allowance after this last one.\nTo make matters worse, they are only giving you a fraction of what you normally receive, WHELP.\nTo maintiain your lifestyle, you decide on the only job that won't break any labor laws.\n\nGOOD LUCK in your endeavors my friend and let's get started.");
            Console.ReadLine();
        }
        public static void StartLemonadestand()
        {
            Console.Clear();
            Console.WriteLine("Alright! All the setup for your lemonadestand is all done; time to start making money.");
            Console.ReadLine();
        }
    }
}
