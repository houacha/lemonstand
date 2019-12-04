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
        public void AddLemons(int amount)
        {
            for (int i = 0; i < amount; i++)
            {
                lemons.Add(lemon = new Lemon(.55, 30, 3));
            }
        }
        public void AddIce(int amount)
        {
            for (int i = 0; i < amount; i++)
            {
                iceCubes.Add(ice = new Ice(.01, 7, 1));
            }
        }
        public void AddSugar(int amount)
        {
            for (int i = 0; i < amount; i++)
            {
                sugarCubes.Add(sugar = new Sugar(.01, 0, 1));
            }
        }
        public void AddCups(int amount)
        {
            for (int i = 0; i < amount; i++)
            {
                cups.Add(cup = new Cups(.15, 0, 8));
            }
        }
        public void Spoil(int counter, List<Weather> today)
        {
            for (int i = 0; i < lemons.Count; i++)
            {
                if (today[counter].actualTemp >= 72)
                {
                    lemons[i].spoilage -= 2;
                }
                else if (today[counter].actualTemp >= 64 && today[counter].actualTemp < 72)
                {
                    lemons[i].spoilage -= 1;
                }
                lemons[i].spoilage -= 1;
            }
            for (int j = 0; j < iceCubes.Count; j++)
            {
                if (today[counter].actualTemp >= 72)
                {
                    iceCubes[j].spoilage -= 2;
                }
                else if (today[counter].actualTemp >= 64 && today[counter].actualTemp < 72)
                {
                    iceCubes[j].spoilage -= 1;
                }
                iceCubes[j].spoilage -= 1;
            }
        }
    }
}
