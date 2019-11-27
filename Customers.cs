using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lemonadestand
{
    class Customers
    {
        public Weather weather = new Weather();
        public int cash;
        public string prefrence;
        public string name;
        public List<Customers> customerList = new List<Customers>();
        public void ForecastPreference(List<Customers> customers)
        {
            for (int i = 0; i < customers.Count ; i++)
            {

            }
        }
    }
}
