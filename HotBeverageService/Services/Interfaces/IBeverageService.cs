using HotBeverageService.Models;
using HotBeverageService.Services.Enums;

namespace HotBeverageService.Services.Interfaces
{
    public interface IBeverageService
    {
        IngredientsModel BrewBeverage(BeverageType beverageType, IngredientsModel ingridients);
    }
}
