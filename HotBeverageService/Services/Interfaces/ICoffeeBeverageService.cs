using HotBeverageService.Models;

namespace HotBeverageService.Services.Interfaces
{
    public interface ICoffeeBeverageService
    {
        IngredientsModel BrewedBeverage(IngredientsModel ingridients, bool requireMilk = true);
        void DisplayMessage();
        bool CheckForMilkRequirement();
    }
}
