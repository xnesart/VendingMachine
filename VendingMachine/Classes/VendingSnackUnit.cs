using System;
using System.Collections.Generic;

namespace VendingMachine.Classes
{
    public class VendingSnackUnit : AbstractVendingUnit
    {
        public VendingSnackUnit(double water, double milk, double coffee, int sugar) : base(water, milk, coffee, sugar)
        {
            Snacks = new List<Snack>();
            AddSnack(AddSnickersSnack());
            AddSnack(AddTwixSnack());
            AddSnack(AddBountySnack());
            AddSnack(AddNutsSnack());
        }

        public void AddSnack(Snack snack)
        {
            Snacks.Add(snack);
        }

        private Snack AddSnickersSnack()
        {
            return new Snack("сникерс", 15);
        }

        private Snack AddTwixSnack()
        {
            return new Snack("твикс", 13);
        }

        private Snack AddBountySnack()
        {
            return new Snack("баунти", 11);
        }

        private Snack AddNutsSnack()
        {
            return new Snack("натс", 13);
        }

        public void PrintAllSnack()
        {
            int counter = 0;
            foreach (var snack in Snacks)
            {
                Console.WriteLine($"Снэк #{counter + 1} {snack.Name}, цена {snack.Price}");
                counter++;
            }
        }

        public bool SellProduct(int numberOfProduct, decimal customerMoney,
            bool paymentMethod)
        {
            numberOfProduct -= 1;
            bool result = false;
            if (paymentMethod == false)
            {
                result = GetPaymentCash(Snacks[numberOfProduct], customerMoney);
            }

            if (paymentMethod)
            {
                result = GetPaymentCard(Snacks[numberOfProduct], customerMoney);
            }

            return result;
        }

        protected bool GetPaymentCash(Snack customerSnack, decimal customerMoney)
        {
            bool status = false;
            decimal change = CalculateChange(customerSnack.Price, customerMoney);

            foreach (var snack in Snacks)
            {
                if (snack == customerSnack)
                {
                    if (customerMoney > customerSnack.Price && this.Balance >= change)
                    {
                        this.Balance += customerMoney - change;
                        Snacks.Remove(snack);
                        status = true;
                        break;
                    }
                }
            }

            return status;
        }

        protected bool GetPaymentCard(Snack customerSnack, decimal customerMoney)
        {
            bool status = false;

            if (customerMoney >= customerSnack.Price)
            {
                customerMoney = customerSnack.Price;
                foreach (var snack in Snacks)
                {
                    if (snack == customerSnack)
                    {
                        this.Balance += customerMoney;
                        Snacks.Remove(snack);
                        status = true;
                        break;
                    }
                }
            }

            return status;
        }

        public virtual bool CheckChange(int choice, decimal customerMoney)
        {
            bool result = false;
            choice--;
            decimal itemPrice = Snacks[choice].Price;

            decimal change = customerMoney - itemPrice;

            if (Balance >= change)
            {
                result = true;
            }
            Console.WriteLine($"Ожидаемая сдача {change} руб");
            return result;
        }

        public int GetSnacksCount()
        {
            return Snacks.Count;
        }
    }
}