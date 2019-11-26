using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lemonadestand
{
    public class Inventory
    {
        public static Cups cup = new Cups(.25, 0);
        public static Sugar sugar = new Sugar(.01, 0);
        public static Ice ice = new Ice(.01, 1);
        public static Lemon lemon = new Lemon(.55, 30);
        public List<Item> allItems = new List<Item> { lemon, ice, sugar, cup };
        public List<Lemon> lemons = new List<Lemon>() { };
        public List<Ice> iceCubes = new List<Ice>() { };
        public List<Sugar> sugarCubes = new List<Sugar> { };
        public List<Cups> cups = new List<Cups> { };
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
    }
}
