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
        public static Cloudy cloudy = new Cloudy();
        public static Rain rainy = new Rain();
        public static Foggy foggy = new Foggy();
        public static Sunny sunny = new Sunny();
        public Random rngNum = new Random();
        public List<Weather> weathers = new List<Weather>() { rainy, sunny, foggy, cloudy };
        public List<Weather> forecast = new List<Weather>() { };
        public static List<int> forecastTemp = new List<int>() { };
        public string[] daysOfTheWeek = new string[] { "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday", "Sunday" };
        public void ShowForecast()
        {
            Console.Clear();
            ForecastGen();
            Console.WriteLine("This week's forecast:" + "\n");
            for (int i = 0; i < forecast.Count; i++)
            {
                switch (forecast[i].name)
                {
                    case "rainy":
                        rainy.SetPercentRainy(rngNum.Next(101));
                        rainy.RandomTemp(rngNum.Next(40, 70));
                        forecastTemp.Add(rainy.temp);
                        Console.WriteLine(daysOfTheWeek[i] + ":" + "\n" + rainy.percentOfHappening + "% " + forecast[i].name + " " + forecast[i].temp + "*F" + "\n");
                        break;
                    case "sunny":
                        sunny.RandomTemp(rngNum.Next(55, 101));
                        forecastTemp.Add(sunny.temp);
                        Console.WriteLine(daysOfTheWeek[i] + ":" + "\n" + forecast[i].name + " " + forecast[i].temp + "*F" + "\n");
                        break;
                    case "foggy":
                        foggy.RandomTemp(rngNum.Next(28, 60));
                        forecastTemp.Add(foggy.temp);
                        Console.WriteLine(daysOfTheWeek[i] + ":" + "\n" + forecast[i].name + " " + forecast[i].temp + "*F" + "\n");
                        break;
                    case "cloudy":
                        cloudy.RandomTemp(rngNum.Next(45, 70));
                        forecastTemp.Add(cloudy.temp);
                        Console.WriteLine(daysOfTheWeek[i] + ":" + "\n" + forecast[i].name + " " + forecast[i].temp + "*F" + "\n");
                        break;
                    default:
                        break;
                }
            }
            Console.ReadLine();
        }
        public void CurrentDayForecast(int counter)
        {
            Console.Clear();
            switch (forecast[counter].name)
            {
                case "rainy":
                    rainy.IsRaining(rngNum.Next(101));
                    rainy.SetActualTemp(rngNum.Next(0, 8), rngNum.Next(2));
                    if (rainy.isRaining == true)
                    {
                        Console.WriteLine("Today is " + daysOfTheWeek[counter] + "." + "\n" + "Today's weather is " + forecast[counter].name + "\n" + "Temperature is: " + forecast[counter].actualTemp + "*F");
                    }
                    else
                    {
                        Console.WriteLine("Today is " + daysOfTheWeek[counter] + "." + "\n" + "Today's weather is cloudy" + "\n" + "Temperature is: " + forecast[counter].actualTemp + "*F");
                    }
                    break;
                case "sunny":
                    sunny.SetActualTemp(rngNum.Next(0, 10), rngNum.Next(2));
                    Console.WriteLine("Today is " + daysOfTheWeek[counter] + "." + "\n" + "Today's weather is " + forecast[counter].name + "\n" + "Temperature is: " + forecast[counter].actualTemp + "*F");
                    break;
                case "foggy":
                    foggy.SetActualTemp(rngNum.Next(0, 9), rngNum.Next(2));
                    Console.WriteLine("Today is " + daysOfTheWeek[counter] + "." + "\n" + "Today's weather is " + forecast[counter].name + "\n" + "Temperature is: " + forecast[counter].actualTemp + "*F");
                    break;
                case "cloudy":
                    cloudy.SetActualTemp(rngNum.Next(0, 11), rngNum.Next(2));
                    Console.WriteLine("Today is " + daysOfTheWeek[counter] + "." + "\n" + "Today's weather is " + forecast[counter].name + "\n" + "Temperature is: " + forecast[counter].actualTemp + "*F");
                    break;
                default:
                    break;
            }
        }
        public void SetActualTemp(int rng, int addOrSub)
        {
            int num = addOrSub;
            int tempRange = rng;
            switch (num)
            {
                case 0:
                    actualTemp = forecastTemp[0] - tempRange;
                    forecastTemp.RemoveAt(0);
                    break;
                case 1:
                    actualTemp = forecastTemp[0] + tempRange;
                    forecastTemp.RemoveAt(0);
                    break;
                default:
                    break;
            }
        }
        public virtual void RandomTemp(int rng) { }
        public void ForecastGen()
        {
            int num;
            for (int i = 0; i < 7; i++)
            {
                num = rngNum.Next(1, 5);
                switch (num)
                {
                    case 1:
                        forecast.Add(weathers[0]);
                        break;
                    case 2:
                        forecast.Add(weathers[1]);
                        break;
                    case 3:
                        forecast.Add(weathers[2]);
                        break;
                    case 4:
                        forecast.Add(weathers[3]);
                        break;
                }
            }

        }
    }
}
