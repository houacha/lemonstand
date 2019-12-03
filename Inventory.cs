using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lemonadestand
{
    public class Inventory
    {
        public static Cups cup;
        public static Sugar sugar;
        public static Ice ice;
        public static Lemon lemon;
        public List<Item> allItems;
        public List<Item> lemons;
        public List<Item> iceCubes;
        public List<Item> sugarCubes;
        public List<Item> cups;
        public List<string> recipeItems;
        public Inventory()
        {
            cup = new Cups(.15, 0, 8);
            sugar = new Sugar(.01, 0, 1);
            ice = new Ice(.01, 7, 1);
            lemon = new Lemon(.55, 30, 3);
            allItems = new List<Item> { lemon, ice, sugar, cup };
            lemons = new List<Item>() { };
            iceCubes = new List<Item>() { };
            sugarCubes = new List<Item> { };
            cups = new List<Item> { };
            recipeItems = new List<string>() { };
        }
        public void AddToRecipe()
        {
            recipeItems.Add("lemon");
            recipeItems.Add("ice");
            recipeItems.Add("sugar");
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
        public void SpoiledByTemp(int temp)
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
