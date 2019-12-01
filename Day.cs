using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lemonadestand
{
    class Day
    {
        public Weather weather = new Weather();
        public Player player1 = new Player();
        public Store store = new Store();
        public int dayCounter = 0;
        public void RunDay()
        {
            if (dayCounter == 0)
            {
                weather.ShowForecast();
            }
            else if (dayCounter == 7)
            {
                dayCounter = 0;
                weather.forecast.Clear();
                weather.ShowForecast();
            }
            weather.CurrentDayForecast(dayCounter);
            player1.ShowPlayerCash();
            UserInterface.GoToStore(player1.inventory,store,player1);
            store.AddItems(player1);
            player1.CheckInventory();
            player1.CheckSpoil();
            UserInterface.MakeRecipe(player1);
            string response;
            do
            {
                response = UserInterface.ConfirmRecipe(player1);
            } while (response == "no");
            UserInterface.PromptWaterAmount(player1);

            dayCounter++;
        }
    }
}
