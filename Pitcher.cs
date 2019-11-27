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
        public int sweetnessLevel;
        public double pricePerCup;
        public int lemonadeLeft;
        public void DetermineSweetness(Player player)
        {
            sweetnessLevel = (player.recipe.sugarCubes * player.inventory.sugar.sweetness) - (player.recipe.lemons * player.inventory.lemon.sourness);
        }
    }
}
