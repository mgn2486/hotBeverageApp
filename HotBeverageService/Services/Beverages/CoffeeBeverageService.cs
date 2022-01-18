using HotBeverageService.Models;
using HotBeverageService.Services.Interfaces;
using System;

namespace HotBeverageService.Services.Beverages
{
    public class CoffeeBeverageService : ICoffeeBeverageService
    {
        private readonly int COFFEE_BEANS = 2;
        private readonly int COFFEE_MILK_UNITS = 1;

        public IngredientsModel BrewedBeverage(IngredientsModel ingridients, bool milkOption = true)
        {
            var ingriedients = new IngredientsModel();

            DisplayMessage();

            if (ingridients.QuantityOfBeans > COFFEE_BEANS)
            {
                ingriedients.QuantityOfBeans = ingridients.QuantityOfBeans - 5;
            } else
            {
                Console.WriteLine("Sorry there is no sufficient BEANS to prepare this beverage");
                return ingridients;
            }

            if (milkOption)
            {
                if (ingridients.UnitsOfMilk > COFFEE_MILK_UNITS)
                {
                    ingriedients.UnitsOfMilk = ingridients.UnitsOfMilk - COFFEE_MILK_UNITS;
                }
                else
                {
                    Console.WriteLine("Sorry there is no sufficient MILK to prepare this beverage");
                    return ingridients;
                }

                Console.WriteLine($"COFFEE with Milk has been Brewed for you...!!!\n");
            }
            else {
                Console.WriteLine($"COFFEE without Milk has been Brewed for you...!!!\n");
            }

            return ingriedients;
        }

        public bool CheckForMilkRequirement()
        {
            var milkAddingOtpion = true;
            Console.WriteLine("Would you like some Milk:\n");
            Console.WriteLine("1. Yes \n2. No. ");
            var addMilkChoice = Console.ReadLine();

            var hasMilk = int.TryParse(addMilkChoice, out int milkRequirmentOption);

            if (hasMilk)
            {
                switch (milkRequirmentOption)
                {
                    case 1:
                        milkAddingOtpion = true;
                        break;

                    case 2:
                        milkAddingOtpion = false;
                        break;

                    default:
                        milkAddingOtpion = true;
                        break;
                }
            }

            return milkAddingOtpion;
        }

        public void DisplayMessage()
        {
            Console.WriteLine("# COFFEE Brewing\n");
        }
    }
}
