namespace DifferentTypesOfClassesExample;

internal sealed class PrimeCustomer : Customer
{
    public PrimeCustomer()
    {
        Console.WriteLine("PrimeCustomer Constructor!!!");
    }
    public double Fees { get; set; } = 1499;
    int DiscountPercent { get; set; }
}