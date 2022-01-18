using HotBeverageService.Models;
using HotBeverageService.Services.Interfaces;
using System;

namespace HotBeverageService.Services.Beverages
{
    public class LatteBeverageService : ILatteBeverageService
    {
        private readonly int LATTE_BEANS = 3;
        private readonly int LATTE_MILK_UNITS = 2;

        public IngredientsModel BrewedBeverage(IngredientsModel ingridients)
        {
            var ingriedients = new IngredientsModel();

            DisplayMessage();

            if (ingridients.QuantityOfBeans > LATTE_BEANS)
            {
                ingriedients.QuantityOfBeans = ingridients.QuantityOfBeans - 5;
            }
            else
            {
                Console.WriteLine("Sorry there is no sufficient BEANS to prepare this beverage");
                return ingridients;
            }

            if (ingridients.UnitsOfMilk > LATTE_MILK_UNITS)
            {
                ingriedients.UnitsOfMilk = ingridients.UnitsOfMilk - LATTE_MILK_UNITS;
            }
            else
            {
                Console.WriteLine("Sorry there is no sufficient MILK to prepare this beverage");
                return ingridients;
            }

            Console.WriteLine("LATTE has been Brewed for you...!!!\n");

            return ingriedients;
        }

        public void DisplayMessage()
        {
            Console.WriteLine("# LATTE Brewing\n");
        }
    }
}
