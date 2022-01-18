using HotBeverageService.Models;
using HotBeverageService.Services.Enums;
using HotBeverageService.Services.Interfaces;

namespace HotBeverageService
{
    public class BeverageService : IBeverageService
    {
        private readonly ICappaccinoBeverageService _cappaccionService;
        private readonly ICoffeeBeverageService _coffeeBeverageService;
        private readonly ILatteBeverageService _latteBeverageService;


        public BeverageService(ICappaccinoBeverageService cappaccionService, ICoffeeBeverageService coffeeBeverageService, ILatteBeverageService latteBeverageService)
        {
            _cappaccionService = cappaccionService;
            _coffeeBeverageService = coffeeBeverageService;
            _latteBeverageService = latteBeverageService;
        }

        public IngredientsModel BrewBeverage(BeverageType beverageType, IngredientsModel ingridients)
        {
            var processedIngridients = new IngredientsModel();

            if (beverageType == BeverageType.Cappaccino)
            {
                processedIngridients = _cappaccionService.BrewedBeverage(ingridients);                
            }

            if (beverageType == BeverageType.Coffee)
            {
                var addMilkOption = _coffeeBeverageService.CheckForMilkRequirement();
                processedIngridients = _coffeeBeverageService.BrewedBeverage(ingridients, addMilkOption);
            }

            if (beverageType == BeverageType.Latte)
            {
                processedIngridients = _latteBeverageService.BrewedBeverage(ingridients);
            }

            return processedIngridients;
        }
    }
}
