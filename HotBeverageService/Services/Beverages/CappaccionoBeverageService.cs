using HotBeverageService.Models;
using HotBeverageService.Services.Interfaces;
using System;

namespace HotBeverageService.Services
{
    public class CappaccionoBeverageService : ICappaccinoBeverageService
    {
        private readonly int CAPPACCINO_BEANS = 5;
        private readonly int CAPPACCINO_MILK_UNITS = 3;

        public IngredientsModel BrewedBeverage( IngredientsModel ingridients)
        {
            var ingriedients = new IngredientsModel();

            DisplayMessage();
            if (ingridients.QuantityOfBeans > CAPPACCINO_BEANS)
            {
                ingriedients.QuantityOfBeans = ingridients.QuantityOfBeans - 5;
            }
            else {
                Console.WriteLine("Sorry there is no sufficient BEANS to prepare this beverage");
                return ingridients;
            }

            if (ingridients.UnitsOfMilk > CAPPACCINO_MILK_UNITS)
            {
                ingriedients.UnitsOfMilk = ingridients.UnitsOfMilk - 5;
            }
            else
            {
                Console.WriteLine("there is no sufficient MILK to prepare this beverage");
                return ingridients;
            }

            Console.WriteLine("CAPPACCINO has been Brewed for you...!!!\n");

            return ingriedients;
        }

        public void DisplayMessage()
        {
            Console.WriteLine("# Capaccino Brewing");
        }
    }
}
