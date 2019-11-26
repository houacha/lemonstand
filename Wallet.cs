using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lemonadestand
{
    public class Wallet
    {
        public double cash;
        public void Income(double income)
        {
            cash += income;
        }
    }
}
