using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lemonadestand
{
    public abstract class Item
    {
        public string name;
        public int amount;
        public double price;
        public int spoilage;
        public int Spoiled(Item item, List<Item> currentItems)
        {
            int spoilCounter = 0;
            int almostSpoiled = 0;
            if (item.spoilage <= 0)
            {
                spoilCounter++;
                currentItems.Remove(item);
                return spoilCounter;
            }
            else if (item.spoilage < 3)
            {
                almostSpoiled++;
                return almostSpoiled;
            }
            else
            {
                return 0;
            }
        }
    }
}
