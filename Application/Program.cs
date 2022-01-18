using HotBeverageService;
using HotBeverageService.Models;
using HotBeverageService.Services;
using HotBeverageService.Services.Beverages;
using HotBeverageService.Services.Enums;
using HotBeverageService.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Application
{
    public class Program
    {
        static void Main(string[] args)
        {
            var serviceProvider = ApplicationIoCContainer();
            var beverageService = serviceProvider.GetService<IBeverageService>();

            var beverageIngridients = new IngredientsModel();

            DisplayMenu();

            var userInput = Console.ReadLine();

            while (!userInput.Equals("Off"))
            {
                bool success = int.TryParse(userInput, out int userChoice);

                if (beverageIngridients.QuantityOfBeans <= 5)
                {
                    Console.WriteLine("YOUR ARE RUNNING OUT OF BEANS PLEASE DO A REFILL\n");
                }

                if (success)
                {
                    switch (userChoice)
                    {
                        case 1:
                            beverageIngridients = beverageService.BrewBeverage(BeverageType.Cappaccino, beverageIngridients);
                            break;

                        case 2:
                            beverageIngridients = beverageService.BrewBeverage(BeverageType.Coffee, beverageIngridients);
                            break;

                        case 3:
                            beverageIngridients = beverageService.BrewBeverage(BeverageType.Latte, beverageIngridients);
                            break;

                        default:
                            Console.WriteLine("Please Kindly select a valid beverage option:\n");
                            break;
                    }

                    DisplayMenu();

                    userInput = Console.ReadLine();
                }
                else
                {
                    Console.WriteLine($"Application will self desctruct we couldn't process your request");
                    return;
                }
            }
            Console.ReadLine();
        }
                

        public static void DisplayMenu()
        {
            Console.WriteLine("Please select the beverage of your choice:\n");
            Console.WriteLine("1. Capaccino \n2. Coffee. \n3. Latte");
        }

        private static ServiceProvider ApplicationIoCContainer()
        {
            return new ServiceCollection()
                .AddSingleton<IBeverageService, BeverageService>()
                .AddSingleton<ICappaccinoBeverageService, CappaccionoBeverageService>()
                .AddSingleton<ICoffeeBeverageService, CoffeeBeverageService>()
                .AddSingleton<ILatteBeverageService, LatteBeverageService>()
                .BuildServiceProvider();
        }
    }
}
