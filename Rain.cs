﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lemonadestand
{
    public class Rain:Weather
    {
        public Rain()
        {
            name = "rainy";
        }
        public override void RandomTemp()
        {
            rngNum = new Random();
            temp = rngNum.Next(40, 70);
        }
    }
}
