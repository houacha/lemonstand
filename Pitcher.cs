using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lemonadestand
{
    public class Pitcher
    {
        public int coldness = 0;
        public double sweetnessLevel = 0;
        public double pricePerCup;
        public int lemonadeLeft = 60;
        public void DetermineSweetness(Player player)
        {
            sweetnessLevel = (player.recipe.sugarCubes * Inventory.sugar.sweetness) - (player.recipe.lemons * Inventory.lemon.sourness);
        }
        public void DetermineColdness(Player player)
        {
            coldness = player.recipe.iceCubes * Inventory.ice.coldness;
        }
    }
}
