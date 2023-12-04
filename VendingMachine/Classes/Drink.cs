namespace VendingMachine.Classes
{
    public class Drink
    {
        public string Name;
        public double AmountOfWater;
        public double AmountOfMilk;
        public double AmountOfCoffee;
        public decimal Price;

        public Drink(string name, double water, double milk, double coffee, decimal price)
        {
            Name = name;
            AmountOfCoffee = coffee;
            AmountOfWater = water;
            AmountOfMilk = milk;
            this.Price = price;
        }
    }
}