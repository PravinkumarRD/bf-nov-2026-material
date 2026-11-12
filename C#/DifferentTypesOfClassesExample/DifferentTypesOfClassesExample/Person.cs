namespace DifferentTypesOfClassesExample;

internal abstract class Person
{
    protected Person()
    {
        Console.WriteLine("Abstract Class Constructor!!!");
    }
    public int SocialId { get; set; }
    public string FullName { get; set; } = string.Empty;
    public string Address { get; set; } = string.Empty;
    public string City { get; set; } = string.Empty;
    public string State { get; set; } = string.Empty;
    public string Phone { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Country { get; set; } = string.Empty;
    public abstract string ChangeAddress(int socialId, string newAddress);
}
