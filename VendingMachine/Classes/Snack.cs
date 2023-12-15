namespace VendingMachine.Classes
{
    public class Snack
    {
        public string Name { get; set; }
        public decimal Price { get; set; }

        public Snack(string name, decimal price)
        {
            Name = name;
            Price = price;
        }
    }
}