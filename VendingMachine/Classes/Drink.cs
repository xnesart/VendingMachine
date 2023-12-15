namespace VendingMachine.Classes
{
    public class Drink
    {
        public string Name { get; set; }
        public double AmountOfWater { get; set; }
        public double AmountOfMilk { get; set; }
        public double AmountOfCoffee { get; set; }
        public decimal Price { get; set; }

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