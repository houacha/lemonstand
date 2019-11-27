using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lemonadestand
{
    public class Inventory
    {
        public static Cups cup = new Cups(.25, 0, 8);
        public static Sugar sugar = new Sugar(.01, 0, 1);
        public static Ice ice = new Ice(.01, 7, 1);
        public static Lemon lemon = new Lemon(.55, 30, 3);
        public List<Item> allItems = new List<Item> { lemon, ice, sugar, cup };
        public List<Item> lemons = new List<Item>() { };
        public List<Item> iceCubes = new List<Item>() { };
        public List<Item> sugarCubes = new List<Item> { };
        public List<Item> cups = new List<Item> { };
        public List<string> recipeItems = new List<string>() { };
        public void AddToRecipe()
        {
            recipeItems.Add("lemon");
            recipeItems.Add("sugar");
            recipeItems.Add("ice");
        }
        public void AddLemons()
        {
            for (int i = 0; i < lemon.amount; i++)
            {
                lemons.Add(lemon);
            }
        }
        public void AddIce()
        {
            for (int i = 0; i < ice.amount; i++)
            {
                iceCubes.Add(ice);
            }
        }
        public void AddSugar()
        {
            for (int i = 0; i < sugar.amount; i++)
            {
                sugarCubes.Add(sugar);
            }
        }
        public void AddCups()
        {
            for (int i = 0; i < cup.amount; i++)
            {
                cups.Add(cup);
            }
        }
        public void SpoilCounter(int temp)
        {
            foreach (var item in lemons)
            {
                lemon.spoilage -= temp;
            }
            foreach (var item in iceCubes)
            {
                ice.spoilage -= temp;
            }
        }
    }
}
