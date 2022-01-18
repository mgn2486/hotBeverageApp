using HotBeverageService.Models;

namespace HotBeverageService.Services.Interfaces
{
    public interface ILatteBeverageService
    {
        IngredientsModel BrewedBeverage(IngredientsModel ingridients);
        void DisplayMessage();
    }
}
