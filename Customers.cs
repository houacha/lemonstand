using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lemonadestand
{
    public class Customers
    {
        public double cash;
        public int tempPreference;
        public double costPreference;
        public int thirst;
        public int sweetPreference;
        public bool willBuy;

        public Customers(int hundred, double money, int number, double cost, int sweet, int ice)
        {
            thirst = hundred;
            int num = number;
            switch (num)
            {
                case 0:
                    sweetPreference = 0 - sweet;
                    break;
                case 1:
                    sweetPreference = sweet;
                    break;
                default:
                    break;
            }
            cash = money;
            tempPreference = ice;
            costPreference = cost;
        }
        public void WillingnessToBuy(int rng, int today, Player player, int customersThirst, int tempPref)
        {
            int num;
            if (today > 70 && tempPreference <= player.pitcher.coldness)
            {
                num = rng;
                if ((customersThirst < 80 && num < customersThirst) || customersThirst < 60)
                {
                    willBuy = true;
                }
            }
            else if (today > 35 && today <= 70 && tempPref >= player.pitcher.coldness)
            {
                num = rng;
                if ((customersThirst < 80 && num < customersThirst) || customersThirst < 35)
                {
                    willBuy = true;
                }
            }
            else
            {
                willBuy = false;
            }
        }
        public void CustomerBuy(Player player, int today, int rng, int customersThirst, double cost, int sweetPref, int tempPref)
        {
            if (sweetPref > 0)
            {
                if (sweetPref > player.pitcher.sweetnessLevel && player.pitcher.sweetnessLevel >= 0 && cost >= player.pitcher.pricePerCup)
                {
                    WillingnessToBuy(rng, today, player, customersThirst, tempPref);
                }
            }
            else
            {
                if (sweetPref < player.pitcher.sweetnessLevel && player.pitcher.sweetnessLevel <= 0 && cost >= player.pitcher.pricePerCup)
                {
                    WillingnessToBuy(rng, today, player, customersThirst, tempPref);
                }
            }
        }
    }
}
