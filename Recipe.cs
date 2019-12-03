using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lemonadestand
{
    public class Recipe
    {
        public int lemons;
        public int iceCubes;
        public int sugarCubes;
        public List<string> theMix = new List<string>() { };
        public int water;
        public void CountItemsInMix()
        {
            for (int i = 0; i < theMix.Count; i++)
            {
                if (theMix[i] == "lemon")
                {
                    lemons += 1;
                }
                else if (theMix[i] == "sugar")
                {
                    sugarCubes += 1;
                }
                else if (theMix[i] == "ice")
                {
                    iceCubes += 1;
                }
                else
                {
                }
            }
        }
    }
}
