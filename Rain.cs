using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lemonadestand
{
    public class Rain : Weather
    {
        public int percentOfHappening;
        public bool isRaining;
        public static List<int> listOfPercent;
        public Rain()
        {
            name = "rainy";
            isRaining = false;
            listOfPercent = new List<int>() { };
        }
        public override void RandomTemp(int rng)
        {
            temp = rng;

        }
        public override void DetermineCostumers(int rng)
        {
            numOfCustomers = rng;
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
