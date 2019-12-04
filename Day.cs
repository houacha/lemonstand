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
        public List<Weather> forecast;
        public static List<int> forecastTemp;
        public static Cloudy cloudy;
        public static Rain rainy;
        public static Foggy foggy;
        public static Sunny sunny;
        public string[] daysOfTheWeek;
        public List<string> options;
        public int numOfBuyers;
        public bool storeOpened;
        public Day(Random rng, Player player, Store store, Weather weather)
        {
            player1 = player;
            numOfBuyers = 0;
            storeOpened = false;
            rngNum = rng;
            this.weather = weather;
            this.store = store;
            cloudy = new Cloudy();
            rainy = new Rain();
            foggy = new Foggy();
            sunny = new Sunny();
            customerList = new List<Customers>() { };
            forecast = new List<Weather>() { };
            forecastTemp = new List<int>() { };
            daysOfTheWeek = new string[] { "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday", "Sunday" };
            options = new List<string>() { "Restock your inventory", "Check inventory", "End day" };
        }
        private void AddRemoveInGameOptions(List<string> options)
        {
            options.Remove("End day");
            options.Add("End day");
        }
        private void ResetListOptions()
        {
            if (!options.Contains("Check inventory"))
            {
                options.Add("Check inventory");
            }
            else if (!options.Contains("Restock your inventory"))
            {
                options.Add("Restock your inventory");
            }
            else if (!options.Contains("End day"))
            {
                options.Add("End day");
            }
            else if (options.Contains("Make lemonade"))
            {
                options.Remove("Make lemonade");
            }
            else if (options.Contains("Start making money"))
            {
                options.Remove("Start making money");
            }
        }
        public bool GameOptions(int dayCounter)
        {
            bool noDrink = false;
            bool noCups = false;
            AddRemoveInGameOptions(options);
            int response = UserInterface.GameMenu(options);
            string index = options[response - 1];
            switch (index.ToLower())
            {
                case "restock your inventory":
                    options.Add("Make lemonade");
                    options.Remove("Restock your inventory");
                    AddRemoveInGameOptions(options);
                    UserInterface.GoToStore(player1.inventory, store, player1);
                    store.AddItems(player1);
                    player1.CheckInventory();
                    return true;
                case "make lemonade":
                    options.Add("Start making money");
                    options.Remove("Make lemonade");
                    AddRemoveInGameOptions(options);
                    UserInterface.MakeRecipe(player1);
                    string answer;
                    do
                    {
                        answer = UserInterface.ConfirmRecipe(player1);
                        AfterConfirmRecipe(answer, player1);
                    } while (answer == "no");
                    return true;
                case "check inventory":
                    player1.CheckInventory();
                    player1.CheckSpoil();
                    return true;
                case "start making money":
                    UserInterface.StartLemonadestand();
                    SetCustomerCount(dayCounter);
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
                    options.Remove("Start making money");
                    options.Remove("Make lemonade");
                    options.Remove("Restock your inventory");
                    storeOpened = true;
                    return true;
                case "end day":
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
                    return false;
                default:
                    break;
            }
            return true;
        }
        public void AfterConfirmRecipe(string response, Player player)
        {
            switch (response)
            {
                case "yes":
                    player.RemoveItems(player);
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
            bool cantMakeMore;
            switch (response)
            {
                case "yes":
                    player.CheckInventory();
                    cantMakeMore = player.RemakeRecipe(player);
                    if (cantMakeMore == true)
                    {
                        drink = true;
                    }
                    else
                    {
                        drink = false;
                    }
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
            List<Weather> weathers = new List<Weather>() { rainy, sunny, foggy, cloudy };
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
        public void SetCustomerCount(int dayCounter)
        {
            switch (forecast[dayCounter].name)
            {
                case "cloudy":
                    cloudy.DetermineCostumers(rngNum.Next(251));
                    GenerateCustomer(cloudy.numOfCustomers);
                    cloudy.numOfCustomers = 0;
                    break;
                case "sunny":
                    sunny.DetermineCostumers(rngNum.Next(501));
                    GenerateCustomer(sunny.numOfCustomers);
                    sunny.numOfCustomers = 0;
                    break;
                case "foggy":
                    foggy.DetermineCostumers(rngNum.Next(167));
                    GenerateCustomer(foggy.numOfCustomers);
                    foggy.numOfCustomers = 0;
                    break;
                case "rainy":
                    rainy.DetermineCostumers(rngNum.Next(126));
                    GenerateCustomer(rainy.numOfCustomers);
                    rainy.numOfCustomers = 0;
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
            int playingDays = 0;
            int totalDays = 0;
            int dayCounter = 0;
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
                    forecast.Clear();
                    ShowForecast();
                }
                CurrentDayForecast(dayCounter);
                player1.ShowPlayerCash();
                bool loop;
                do
                {
                    loop = GameOptions(dayCounter);
                } while (loop == true);
                ResetListOptions();
                customerList.Clear();
                player1.recipe.theMix.Clear();
                numOfBuyers = 0;
                dayCounter++;
                totalDays++;
                if (dayCounter == 7)
                {
                    dayCounter = 0;
                }
            } while (player1.goalMoney != player1.wallet.cash && !(player1.wallet.cash == 0 && player1.inventory.iceCubes.Count == 0 && player1.inventory.sugarCubes.Count == 0 && player1.inventory.lemons.Count == 0) && totalDays != playingDays);
        }
    }
}
