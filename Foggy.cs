﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lemonadestand
{
    public class Foggy:Weather
    {

        public Foggy()
        {
            name = "foggy";
        }
        public override void RandomTemp(int rng)
        {
            temp = rng;

        }
    }
}
