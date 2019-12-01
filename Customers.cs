using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lemonadestand
{
    class Customers
    {
        public double cash;
        public int tempPreference;
        public double costPreference;
        public int thirst;
        public Random range = new Random();
        //public string name;
        //public List<string> nameList = new List<string>() { };
        public Customers()
        {
            thirst = range.Next(101);
            //int nameIndex = range.Next(nameList.Count);
            //name = nameList[nameIndex];
            cash = Convert.ToDouble(range.Next(6));
            tempPreference = range.Next(101);
            costPreference = range.Next(3);
        }
    }
}
