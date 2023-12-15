namespace VendingMachine.Classes
{
    public class VendingCoffeeUnit: AbstractVendingUnit
    {
        public VendingCoffeeUnit(double water, double milk, double coffee, int sugar) : base(water, milk, coffee, sugar)
        {
            AddDrink(AddRaffDrink());
            AddDrink(AddGlasseDrink());
        }

        private Drink AddRaffDrink()
        {
            return new Drink("раф", 1, 2, 2, 10);
        }
        private Drink AddGlasseDrink()
        {
            return new Drink("гляссе", 1, 2, 1, 8);
        }
    }
}