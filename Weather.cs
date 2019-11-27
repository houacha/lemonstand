using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lemonadestand
{
    public class Weather
    {
        public static Cloudy cloudy = new Cloudy();
        public static Rain rainy = new Rain();
        public static Foggy foggy = new Foggy();
        public static Sunny sunny = new Sunny();
        public string name;
        public List<Weather> weathers = new List<Weather>() { rainy, sunny, foggy, cloudy };
        public List<Weather> forecast = new List<Weather>() { };
        public int temp;
        public Random rngNum;
        public virtual void RandomTemp() { }
        public void ForecastGen()
        {
            for (int i = 0; i < 7; i++)
            {
                int num = rngNum.Next(1, 5);
                switch (num)
                {
                    case 1:
                        forecast.Add(weathers[0]);
                        rainy.RandomTemp();
                        break;
                    case 2:
                        forecast.Add(weathers[1]);
                        sunny.RandomTemp();
                        break;
                    case 3:
                        forecast.Add(weathers[2]);
                        foggy.RandomTemp();
                        break;
                    case 4:
                        forecast.Add(weathers[3]);
                        cloudy.RandomTemp();
                        break;
                }
            }

        }
    }
}
