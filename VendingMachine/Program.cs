using System;
using VendingMachine.Classes;

namespace VendingMachine
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            while (true)
            {
                VendingUnit vendingUnit = new VendingUnit(10, 10, 10, 10);
                Drink coffee = new Drink("кофе", 1, 1, 1, 5);
                vendingUnit.AddDrink(coffee);
                vendingUnit.AddDrink(coffee);
                vendingUnit.AddDrink(coffee);
                vendingUnit.PrintAllDrinks();
                
                try
                {
                    Console.WriteLine("Выберите напиток, введя цифру напитка, введите 0, чтобы выйти");
                    int drinkChoice = int.Parse(Console.ReadLine());

                    if (drinkChoice <= 0 || drinkChoice > vendingUnit.GetProductCount())
                    {
                        Console.WriteLine("Выходим");
                        break;
                    }

                    Console.WriteLine("Сколько сахара вам нужно?");
                    int sugarChoice = int.Parse(Console.ReadLine());
                    if (sugarChoice < 0 || sugarChoice > vendingUnit.GetSugarCount())
                    {
                        Console.WriteLine("У нас нет столько сахара, ошибка");
                        break;
                    }

                    Console.WriteLine("Нажмите 1, чтобы заплатить картой, нажмите 0, чтобы заплатить наличными");
                    int paymentChoice = int.Parse(Console.ReadLine());
                    bool paymentMethod = false;

                    if (paymentChoice > vendingUnit.GetProductCount() || paymentChoice < 0)
                    {
                        Console.WriteLine("Введите либо 1 либо 0, ошибка");
                        break;
                    }

                    if (paymentChoice == 0)
                    {
                        paymentMethod = false;
                    }
                    else
                    {
                        paymentMethod = true;
                    }

                    Console.WriteLine("Внесите деньги");
                    decimal money = decimal.Parse(Console.ReadLine());

                    if (money <= 0 || vendingUnit.CheckChange(money) == false)
                    {
                        Console.WriteLine(
                            "Вы внесли недостаточно или слишком много денег, попробуйте заплатить картой, ошибка");
                        break;
                    }

                    if (sugarChoice > vendingUnit.GetSugarCount())
                    {
                        Console.WriteLine("У нас нет столько сахара, отмена покупки");
                        break;
                    }

                    if (drinkChoice < 0 || drinkChoice > vendingUnit.GetProductCount())
                    {
                        Console.WriteLine("-----------------");
                        Console.WriteLine("Вы ввели неверную позицию напитка, попробуйте ещё раз");
                        Console.WriteLine("-----------------");
                        continue;
                    }

                    Console.WriteLine("Введите цифру напитка");

                    bool res = vendingUnit.SellProduct(drinkChoice, sugarChoice, money, paymentMethod);
                    vendingUnit.CheckProblems();
                    vendingUnit.ShowBalance();

                    if (res)
                    {
                        Console.WriteLine("Спасибо за покупку, приходите ещё!");
                        break;
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine(
                        "Вам нужно ввести цифру напитка из предложенных или отказаться от покупки, ошибка!");
                }
            }
        }
    }
}