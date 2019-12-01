using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lemonadestand
{
    public class Rain:Weather
    {
        public int percentOfHappening;
        public bool isRaining = false;
        public static List<int> listOfPercent = new List<int>() { };
        public Rain()
        {
            name = "rainy";
        }
        public override void RandomTemp(int rng)
        {
            temp = rng;

        }
        public void SetPercentRainy(int rng)
        {
            percentOfHappening = rng;
            listOfPercent.Add(percentOfHappening);
        }
        public void IsRaining(int rng)
        {
            int raining = rng;
            if (raining <= listOfPercent[0])
            {
                isRaining = true;
                listOfPercent.RemoveAt(0);
            }
            else
            {
                listOfPercent.RemoveAt(0);
            }
        }
    }
}
