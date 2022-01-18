using HotBeverageService;
using HotBeverageService.Models;
using HotBeverageService.Services.Beverages;
using HotBeverageService.Services.Enums;
using HotBeverageService.Services.Interfaces;
using NSubstitute;
using NUnit.Framework;
using System;
using System.IO;

namespace HotBeverageServiceUnitTests
{
    [TestFixture]
    public class Testing_Berverage_Service
    {

        [Test]
        public void WhenRequestedForBevergeTypeCoffee_without_milk_Should_prompt_the_user_for_milk()
        {
            // arrange
            var cappaccionService = Substitute.For<ICappaccinoBeverageService>();
            var coffeeBeverageService = new CoffeeBeverageService();
            var latteBeverageService = Substitute.For<ILatteBeverageService>();
            var stringWriter = new StringWriter();
            Console.SetOut(stringWriter);

            var stringReader = new StringReader("Would you like some Milk:\n");
            Console.SetIn(stringReader);
            var line1 = Console.ReadLine();

            var InitialIngridients = new IngredientsModel() {
                QuantityOfBeans = 25,
                UnitsOfMilk = 20
            };

            var beverageService = new BeverageService(cappaccionService, coffeeBeverageService, latteBeverageService);

            // act
            var response = beverageService.BrewBeverage(BeverageType.Coffee, InitialIngridients);

            // assert
            Assert.AreEqual("Would you like some Milk:", line1);
            var output = stringWriter.ToString().Length;
            Assert.AreEqual(113, output);
        }

        [Test]
        public void WhenRequestedForBevergeTypeCoffee_without_milk_Should_reduce_only_the_amount_of_beans_consumed()
        {
            // arrange
            var cappaccionService = Substitute.For<ICappaccinoBeverageService>();
            var coffeeBeverageService = new CoffeeBeverageService();
            var latteBeverageService = Substitute.For<ILatteBeverageService>();
            var stringWriter = new StringWriter();
            Console.SetOut(stringWriter);

            var stringReader = new StringReader("Would you like some Milk:\n");
            Console.SetIn(stringReader);
            var line1 = Console.ReadLine();

            var InitialIngridients = new IngredientsModel()
            {
                QuantityOfBeans = 25,
                UnitsOfMilk = 20
            };

            var expectedReturnedEngridients = new IngredientsModel()
            {
                QuantityOfBeans = 20,
                UnitsOfMilk = 19
            };

            var beverageService = new BeverageService(cappaccionService, coffeeBeverageService, latteBeverageService);

            // act
            var response = beverageService.BrewBeverage(BeverageType.Coffee, InitialIngridients);

            // assert
            Assert.AreEqual(expectedReturnedEngridients.QuantityOfBeans, response.QuantityOfBeans);
            Assert.AreEqual(expectedReturnedEngridients.UnitsOfMilk, response.UnitsOfMilk);
        }

        [Test]
        public void WhenRequestedForBevergeTypeCoffee_without_milk_Should_Return_Coffee_without_milk()
        {
            // arrange
            var cappaccionService = Substitute.For<ICappaccinoBeverageService>();
            var coffeeBeverageService = Substitute.For<ICoffeeBeverageService>();
            var latteBeverageService = Substitute.For<ILatteBeverageService>();

            var InitialIngridients = new IngredientsModel()
            {
                QuantityOfBeans = 25,
                UnitsOfMilk = 20
            };

            var expectedReturnedEngridients = new IngredientsModel()
            {
                QuantityOfBeans = 23,
                UnitsOfMilk = 19
            };

            var beverageService = new BeverageService(cappaccionService, coffeeBeverageService, latteBeverageService);

            // act
            var response = beverageService.BrewBeverage(BeverageType.Coffee, InitialIngridients);

            // assert
            coffeeBeverageService.Received().BrewedBeverage(
                                        Arg.Is<IngredientsModel>(u => u.QuantityOfBeans == 25 && u.UnitsOfMilk == 20),
                                        Arg.Is<bool>(x => x == false));

            coffeeBeverageService.Received(1).CheckForMilkRequirement();
        }


        [Test]
        public void WhenRequestedForBevergeOfTypeCoffee_with_milk_Should_Return_Coffee_with_milk()
        {
            // arrange
            var cappaccionService = Substitute.For<ICappaccinoBeverageService>();
            var coffeeBeverageService = Substitute.For<ICoffeeBeverageService>();
            var latteBeverageService = Substitute.For<ILatteBeverageService>();

            coffeeBeverageService.CheckForMilkRequirement().Returns(true);

            var InitialIngridients = new IngredientsModel()
            {
                QuantityOfBeans = 25,
                UnitsOfMilk = 20
            };

            var beverageService = new BeverageService(cappaccionService, coffeeBeverageService, latteBeverageService);

            // act
            var response = beverageService.BrewBeverage(BeverageType.Coffee, InitialIngridients);

            // assert
            coffeeBeverageService.Received().BrewedBeverage(
                                        Arg.Is<IngredientsModel>(u => u.QuantityOfBeans == 25 && u.UnitsOfMilk == 20),
                                        Arg.Is<bool>(y => y == true)
                                        ); 
        }

        [Test]
        public void WhenRequestedForBevergeTypeCapaccino_Should_Return_Coffee_without_milk()
        {
            // arrange
            var cappaccionService = Substitute.For<ICappaccinoBeverageService>();
            var coffeeBeverageService = Substitute.For<ICoffeeBeverageService>();
            var latteBeverageService = Substitute.For<ILatteBeverageService>();

            var ingridients = new IngredientsModel()
            {
                QuantityOfBeans = 25,
                UnitsOfMilk = 20
            };

            var beverageService = new BeverageService(cappaccionService, coffeeBeverageService, latteBeverageService);

            // act
            var response = beverageService.BrewBeverage(BeverageType.Cappaccino, ingridients);

            // assert
            cappaccionService.Received().BrewedBeverage(
                                        Arg.Is<IngredientsModel>(u => u.QuantityOfBeans == 25 && u.UnitsOfMilk == 20)
                                        );
        }

        [Test]
        public void WhenRequestedForBevergeTypeLattee_Should_Return_Brew_Lattee()
        {
            // arrange
            var cappaccionService = Substitute.For<ICappaccinoBeverageService>();
            var coffeeBeverageService = Substitute.For<ICoffeeBeverageService>();
            var latteBeverageService = Substitute.For<ILatteBeverageService>();

            var ingridients = new IngredientsModel()
            {
                QuantityOfBeans = 25,
                UnitsOfMilk = 20
            };

            var beverageService = new BeverageService(cappaccionService, coffeeBeverageService, latteBeverageService);

            // act
            var response = beverageService.BrewBeverage(BeverageType.Latte, ingridients);

            // assert
            latteBeverageService.Received().BrewedBeverage(
                                        Arg.Is<IngredientsModel>(u => u.QuantityOfBeans == 25 && u.UnitsOfMilk == 20)
                                        );
        }
    }
}
