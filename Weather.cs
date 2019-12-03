using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lemonadestand
{
    public class Weather
    {
        public string name;
        public int actualTemp;
        public int temp;
        public int numOfCustomers;
        public void SetActualTemp(int rng, int addOrSub, int forecast)
        {
            int num = addOrSub;
            int tempRange = rng;
            switch (num)
            {
                case 0:
                    actualTemp = forecast - tempRange;
                    Day.forecastTemp.RemoveAt(0);
                    break;
                case 1:
                    actualTemp = forecast + tempRange;
                    Day.forecastTemp.RemoveAt(0);
                    break;
                default:
                    break;
            }
        }
        public virtual void RandomTemp(int rng) { }
        public virtual void DetermineCostumers(int rng) { }
    }
}
