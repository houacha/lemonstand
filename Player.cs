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
        public Inventory inventory;
        public Wallet wallet;
        public Pitcher pitcher;
        public Recipe recipe;
        public bool hasEnoughMoney;
        public double goalMoney;
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
        public bool RemakeRecipe(Player player)
        {
            if (inventory.lemons.Count == 0 || inventory.iceCubes.Count == 0 || inventory.sugarCubes.Count == 0)
            {
                Console.WriteLine("You're currently out of one or more items and can't make your recipe.\nTime to pack up for the day.");
                Console.ReadLine();
                return true;
            }
            else if (inventory.lemons.Count >= recipe.lemons && inventory.iceCubes.Count >= recipe.iceCubes && inventory.sugarCubes.Count >= recipe.sugarCubes)
            {
                Console.Clear();
                player.RemoveItems(player);
                pitcher.lemonadeLeft = 64;
                Console.WriteLine("You just made a new batch of lemanade.");
                Console.ReadLine();
                return false;
            }
            else
            {
                Console.WriteLine("You don't have enough ingredients for another pitcher of lemonade.\nLet's just hope you didn't miss out on too much profit.");
                Console.ReadLine();
                return true;
            }
        }
        public void CheckInventory()
        {
            Console.WriteLine("You look at everyting you have and see that you currently have:" + "\n" + inventory.iceCubes.Count + " " + inventory.allItems[1].name);
            Console.WriteLine(inventory.lemons.Count + " " + inventory.allItems[0].name);
            Console.WriteLine(inventory.sugarCubes.Count + " " + inventory.allItems[2].name);
            Console.WriteLine(inventory.cups.Count + " " + inventory.allItems[3].name);
            Console.ReadLine();
        }
        public void CheckSpoil()
        {
            Console.Clear();
            Console.WriteLine("You check your inventory to make sure everything looks good.");
            int count;
            if (inventory.iceCubes.Count > 0)
            {
                count = inventory.iceCubes.Count;
                int check = 0;
                for (int i = 0; i < inventory.iceCubes.Count; i++)
                {
                    check += inventory.iceCubes[i].Spoiled(inventory.iceCubes[i], inventory.iceCubes);
                    if (check > 0)
                    {
                        i = 0;
                    }
                    else
                    {
                    }
                }
                if (check > 0 && (count - inventory.iceCubes.Count) > 0)
                {
                    Console.WriteLine("While looking through your cooler you realized that " + check + " ice cubes has faded to the aether.");
                }
                else if (check > 0 && (count - inventory.iceCubes.Count) == 0)
                {
                    Console.WriteLine("You take a quick peek at your stockpile and notice that " + check + " ice cubes are going to melt soon.");
                }
            }
            if (inventory.lemons.Count > 0)
            {
                count = inventory.lemons.Count;
                int check = 0;
                for (int l = 0; l < inventory.lemons.Count; l++)
                {
                    check += inventory.lemons[l].Spoiled(inventory.lemons[l], inventory.lemons);
                    if (check > 0)
                    {
                        l = 0;
                    }
                    else
                    {
                    }
                }
                if (check > 0 && (count - inventory.lemons.Count) > 0)
                {
                    Console.WriteLine("When you were counting your lemons, you were startled by the fact that " + check + " lemons sprouted legs and ran off into the sunset.");
                }
                else if (check > 0 && (count - inventory.lemons.Count) == 0)
                {
                    Console.WriteLine("You look at your inventory and saw that " + check + " lemons looked like they were going roots. You brush off those tandrils and just put them back into your bag.");
                }
            }
            Console.ReadLine();
        }
        public void AddItems(int loopAmount, Player player, int currentLoop)
        {
            for (int j = 0; j < loopAmount; j++)
            {
                player.recipe.theMix.Add(player.inventory.recipeItems[currentLoop]);
            }
        }
        public void RemoveItems(Player player)
        {
            for (int i = 0; i < player.recipe.lemons; i++)
            {
                player.inventory.lemons.RemoveAt(0);
            }
            for (int j = 0; j < player.recipe.iceCubes; j++)
            {
                player.inventory.iceCubes.RemoveAt(0);
            }
            for (int k = 0; k < player.recipe.sugarCubes; k++)
            {
                player.inventory.sugarCubes.RemoveAt(0);
            }
        }
        public Player()
        {
            inventory = new Inventory();
            wallet = new Wallet();
            pitcher = new Pitcher();
            recipe = new Recipe();
            hasEnoughMoney = true;
            wallet.cash = 20.00;
        }
    }
}
