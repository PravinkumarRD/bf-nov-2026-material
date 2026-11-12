namespace DifferentTypesOfClassesExample;

internal class Customer : Person
{
    public Customer()
    {
        Console.WriteLine("Customer Constructor!!!");
    }
    public int CustomerId { get; set; }
    public override string ChangeAddress(int socialId, string newAddress)
    {
        return $"Address changed from {Address} for SocialId: {socialId} to New Address: {newAddress}";
    }
}
