using System;
using System.Collections.Generic;

namespace VendingMachine.Classes
{
    public class VendingUnit
    {
        private decimal Balance { get; set; }
        private List<Drink> Products { get; set; }
        private double CountOfWater { get; set; }
        private double CountOfCoffee { get; set; }
        private double CountOfMilk { get; set; }
        private int CountOfSugar { get; set; }

        public VendingUnit(double water, double milk, double coffee, int sugar)
        {
            Balance = 10;
            CountOfWater = water;
            CountOfMilk = milk;
            CountOfCoffee = coffee;
            CountOfSugar = sugar;
            Products = new List<Drink>();
            AddDrink(AddCocoaDrink());
            AddDrink(AddLatteDrink());
            AddDrink(AddCoffeeDrink());
        }

        public bool AddDrink(Drink drink)
        {
            bool status = false;
            if (CountOfWater >= drink.AmountOfWater && CountOfMilk >= drink.AmountOfMilk &&
                CountOfCoffee >= drink.AmountOfCoffee)
            {
                CountOfWater -= drink.AmountOfWater;
                CountOfMilk -= drink.AmountOfMilk;
                CountOfCoffee -= drink.AmountOfCoffee;

                Products.Add(drink);
                status = true;
                return status;
            }

            return status;
        }


        public bool SellProduct(int numberOfProduct, int countOfCustomerSugar, decimal customerMoney,
            bool paymentMethod)
        {
            numberOfProduct -= 1;
            bool result = false;
            if (paymentMethod == false && countOfCustomerSugar <= CountOfSugar)
            {
                CountOfSugar -= countOfCustomerSugar;
                result = GetPaymentCash(Products[numberOfProduct], customerMoney);
            }

            if (paymentMethod && countOfCustomerSugar <= CountOfSugar)
            {
                CountOfSugar -= countOfCustomerSugar;
                result = GetPaymentCard(Products[numberOfProduct], customerMoney);
            }

            return result;
        }

        public void PrintAllDrinks()
        {
            int counter = 0;
            foreach (var drink in Products)
            {
                Console.WriteLine($"Напиток под номером {counter + 1} это {drink.Name}");
                counter++;
            }
        }

        public void CheckProblems()
        {
            Console.WriteLine($"Количество напитков = {Products.Count}");
            Console.WriteLine($"Количество воды = {CountOfWater}");
            Console.WriteLine($"Количество молока = {CountOfMilk}");
            Console.WriteLine($"Количество кофе = {CountOfCoffee}");
            Console.WriteLine($"Количество сахара = {CountOfSugar}");
        }

        public void ShowBalance()
        {
            Console.WriteLine($"Баланс на текущий момент = {Balance}");
        }

        public int GetProductCount()
        {
            return Products.Count;
        }

        public int GetSugarCount()
        {
            return CountOfSugar;
        }

        public bool CheckChange(decimal customerMoney)
        {
            bool result = false;
            decimal maxPrice = 0;

            foreach (var drink in Products)
            {
                if (maxPrice < drink.Price)
                {
                    maxPrice = drink.Price;
                }
            }

            decimal change = customerMoney - maxPrice;

            if (Balance >= change)
            {
                result = true;
            }

            return result;
        }

        private bool GetPaymentCash(Drink sellDrink, decimal customerMoney)
        {
            bool status = false;
            decimal change = CalculateChange(sellDrink.Price, customerMoney);

            foreach (var drink in Products)
            {
                if (drink == sellDrink)
                {
                    if (customerMoney > sellDrink.Price && this.Balance >= change)
                    {
                        this.Balance += customerMoney - change;
                        Products.Remove(drink);
                        status = true;
                        break;
                    }
                }
            }

            return status;
        }

        private bool GetPaymentCard(Drink sellDrink, decimal customerMoney)
        {
            bool status = false;

            if (customerMoney >= sellDrink.Price)
            {
                customerMoney = sellDrink.Price;
                foreach (var drink in Products)
                {
                    if (drink == sellDrink)
                    {
                        this.Balance += customerMoney;
                        Products.Remove(drink);
                        status = true;
                        break;
                    }
                }
            }

            return status;
        }

        private Drink AddCoffeeDrink()
        {
            return new Drink("кофе", 1, 1, 1, 5);
        }

        private Drink AddCocoaDrink()
        {
            return new Drink("какао", 1, 1, 0.3, 3);
        }

        private Drink AddLatteDrink()
        {
            return new Drink("латтэ", 1, 2, 1, 6);
        }


        private decimal CalculateChange(decimal price, decimal money)
        {
            decimal change = 0;
            if (money >= price)
            {
                change = money - price;
            }

            return change;
        }
    }
}