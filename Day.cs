using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lemonadestand
{
    class Day
    {
        public Weather weather;
        public Player player1;
        public Customers customers;
        public Store store;
        public Random rngNum;
        public List<Customers> customerList;
        public List<Weather> weathers;
        public List<Weather> forecast;
        public static List<int> forecastTemp;
        public static Cloudy cloudy;
        public static Rain rainy;
        public static Foggy foggy;
        public static Sunny sunny;
        public int dayCounter;
        public int totalDays;
        public int playingDays;
        public int numOfBuyers;
        public bool storeOpened;
        public bool noCups;
        public bool noDrink;
        public string[] daysOfTheWeek;
        public Day(Random rng)
        {
            rngNum = rng;
            weather = new Weather();
            player1 = new Player();
            store = new Store();
            dayCounter = 0;
            cloudy = new Cloudy();
            rainy = new Rain();
            foggy = new Foggy();
            sunny = new Sunny();
            customerList = new List<Customers>() { };
            weathers = new List<Weather>() { rainy, sunny, foggy, cloudy };
            forecast = new List<Weather>() { };
            forecastTemp = new List<int>() { };
            daysOfTheWeek = new string[] { "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday", "Sunday" };
        }
        public void GameOptions()
        {
            switch (UserInterface.GameMenu())
            {
                case 1:
                    UserInterface.GoToStore(player1.inventory, store, player1);
                    store.AddItems(player1);
                    player1.CheckInventory();
                    player1.CheckSpoil();
                    break;
                case 2:
                    UserInterface.MakeRecipe(player1);
                    string response;
                    do
                    {
                        response = UserInterface.ConfirmRecipe(player1);
                        AfterConfirmRecipe(response, player1);
                    } while (response == "no");
                    break;
                case 3:
                    UserInterface.StartLemonadestand();
                    SetCustomerCount();
                    for (int i = 0; i < customerList.Count; i++)
                    {
                        noCups = UserInterface.OutOfCups(player1);
                        if (noCups == true)
                        {
                            break;
                        }
                        string lemRes = UserInterface.OutOfLemonade(player1);
                        noDrink = AfterOutLemonade(lemRes, player1);
                        if (noDrink == true)
                        {
                            break;
                        }
                        customers.CustomerBuy(player1, forecast[0].actualTemp, rngNum.Next(101), customerList[i].thirst, customerList[i].costPreference, customerList[i].sweetPreference, customerList[i].tempPreference);
                        if (customers.willBuy == true)
                        {
                            player1.pitcher.PourDrink();
                            player1.inventory.cups.RemoveAt(0);
                            numOfBuyers++;
                        }
                        customers.willBuy = false;
                    }
                    storeOpened = true;
                    break;
                case 4:
                    double profit = numOfBuyers * player1.pitcher.pricePerCup;
                    player1.wallet.cash += profit;
                    if (noCups == true)
                    {
                        Console.WriteLine("You missed out on " + (customerList.Count - numOfBuyers) + " potential customers.\nWhat a damn shame.\nMaybe buy enough items next time.");
                    }
                    if (storeOpened == false)
                    {
                        Console.WriteLine("Didn't want to want to open up today eh. That's ok no profit but no loss, yet.......");
                    }
                    else if (numOfBuyers == 0 && storeOpened == true)
                    {
                        Console.WriteLine("No one wanted to buy your lemonade today.\nMaybe you should try a different recipe or price.");
                    }
                    else
                    {
                        Console.WriteLine("Today " + customerList.Count + " people came to your rinky-dink stand but only " + numOfBuyers + " people were thirsty enough to try your lemonade.\nYou, however, made $" + profit + ".\nConsider that a win and let's do this again tomorrow.");
                    }
                    Console.ReadLine();
                    dayCounter++;
                    totalDays++;
                    forecast.RemoveAt(0);
                    if (dayCounter == 6)
                    {
                        dayCounter = 0;
                    }
                    break;
                default:
                    break;
            }
        }
        public void AfterConfirmRecipe(string response, Player player)
        {
            switch (response)
            {
                case "yes":
                    UserInterface.RemoveItems(player);
                    UserInterface.PromptWaterAmount(player);
                    UserInterface.CupCharge(player);
                    player.pitcher.DetermineSweetness(player);
                    player.pitcher.DetermineColdness(player);
                    break;
                case "no":
                    player.recipe.theMix.Clear();
                    player.inventory.recipeItems.Clear();
                    UserInterface.MakeRecipe(player);
                    break;
                default:
                    break;
            }
        }
        public bool AfterOutLemonade(string response, Player player)
        {
            bool drink = false;
            switch (response)
            {
                case "yes":
                    player.CheckInventory();
                    player.RemakeRecipe(player);
                    drink = false;
                    break;
                case "no":
                    drink = true;
                    break;
                default:
                    break;
            }
            return drink;
        }
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
                    rainy.SetActualTemp(rngNum.Next(0, 8), rngNum.Next(2), forecastTemp[0]);
                    if (rainy.isRaining == true)
                    {
                        Console.WriteLine("Today is " + daysOfTheWeek[counter] + "." + "\n" + "Today's weather is " + forecast[counter].name + "\n" + "Temperature is: " + forecast[counter].actualTemp + "*F");
                        rainy.name = "rainy";
                    }
                    else
                    {
                        Console.WriteLine("Today is " + daysOfTheWeek[counter] + "." + "\n" + "Today's weather is cloudy" + "\n" + "Temperature is: " + forecast[counter].actualTemp + "*F");
                        rainy.name = "cloudy";
                    }
                    break;
                case "sunny":
                    sunny.SetActualTemp(rngNum.Next(0, 10), rngNum.Next(2), forecastTemp[0]);
                    Console.WriteLine("Today is " + daysOfTheWeek[counter] + "." + "\n" + "Today's weather is " + forecast[counter].name + "\n" + "Temperature is: " + forecast[counter].actualTemp + "*F");
                    break;
                case "foggy":
                    foggy.SetActualTemp(rngNum.Next(0, 9), rngNum.Next(2), forecastTemp[0]);
                    Console.WriteLine("Today is " + daysOfTheWeek[counter] + "." + "\n" + "Today's weather is " + forecast[counter].name + "\n" + "Temperature is: " + forecast[counter].actualTemp + "*F");
                    break;
                case "cloudy":
                    cloudy.SetActualTemp(rngNum.Next(0, 11), rngNum.Next(2), forecastTemp[0]);
                    Console.WriteLine("Today is " + daysOfTheWeek[counter] + "." + "\n" + "Today's weather is " + forecast[counter].name + "\n" + "Temperature is: " + forecast[counter].actualTemp + "*F");
                    break;
                default:
                    break;
            }
        }
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
        public void SetCustomerCount()
        {
            switch (forecast[dayCounter].name)
            {
                case "cloudy":
                    cloudy.DetermineCostumers(rngNum.Next(251));
                    GenerateCustomer(cloudy.numOfCustomers);
                    break;
                case "sunny":
                    sunny.DetermineCostumers(rngNum.Next(501));
                    GenerateCustomer(sunny.numOfCustomers);
                    break;
                case "foggy":
                    foggy.DetermineCostumers(rngNum.Next(167));
                    GenerateCustomer(foggy.numOfCustomers);
                    break;
                case "rainy":
                    rainy.DetermineCostumers(rngNum.Next(126));
                    GenerateCustomer(rainy.numOfCustomers);
                    break;
                default:
                    break;
            }
        }
        public void GenerateCustomer(int count)
        {
            for (int i = 0; i < count; i++)
            {
                customers = new Customers(rngNum.Next(101), (rngNum.NextDouble() * 6), rngNum.Next(2), (rngNum.NextDouble() * 3), rngNum.Next(11), rngNum.Next(11));
                customerList.Add(customers);
            }
        }
        public void RunDay()
        {
            player1.goalMoney = UserInterface.GoalToReach();
            if (totalDays == 7 && player1.wallet.cash < (player1.goalMoney / 2))
            {
                playingDays = UserInterface.DaysOfPlaying();
                totalDays = 0;
            }
            do
            {
                if (dayCounter == 0)
                {
                    ShowForecast();
                }
                CurrentDayForecast(dayCounter);
                storeOpened = false;
                player1.ShowPlayerCash();
                GameOptions();
            } while (player1.goalMoney != player1.wallet.cash || !(player1.wallet.cash == 0 && player1.inventory.iceCubes.Count == 0 && player1.inventory.sugarCubes.Count == 0 && player1.inventory.lemons.Count == 0) || totalDays != playingDays);
        }
    }
}
