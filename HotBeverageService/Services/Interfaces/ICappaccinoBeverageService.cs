using HotBeverageService.Models;

namespace HotBeverageService.Services.Interfaces
{
    public interface ICappaccinoBeverageService
    {
        IngredientsModel BrewedBeverage(IngredientsModel ingridients);
        void DisplayMessage();
    }
}
