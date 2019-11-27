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
        public void Spoiled(Item item, List<Item> currentItems)
        {
            if (spoilage <= 0)
            {
                currentItems.Remove(item);
            }
        }
    }
}
