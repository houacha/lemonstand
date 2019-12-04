using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lemonadestand
{
    public class Pitcher
    {
        public int coldness;
        public double sweetnessLevel;
        public double pricePerCup;
        public int lemonadeLeft;
        public Pitcher()
        {
            coldness = 0;
            sweetnessLevel = 0;
            lemonadeLeft = 0;
        }
        public void DetermineSweetness(Player player)
        {
            sweetnessLevel = ((player.recipe.sugarCubes * Inventory.sugar.sweetness) - (player.recipe.lemons * Inventory.lemon.sourness)) / player.recipe.water;
        }
        public void DetermineColdness(Player player)
        {
            coldness = player.recipe.iceCubes * Inventory.ice.coldness;
        }
        public void PourDrink()
        {
            lemonadeLeft -= Inventory.cup.ounces;
        }
    }
}
