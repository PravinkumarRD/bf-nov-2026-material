namespace DifferentTypesOfClassesExample;

internal class Parent
{
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    private int SocialId { get; set; }
    protected string PAN { get; set; } = string.Empty;
}

internal class  Child : Parent
{
    public Child()
    {
        
    }
}
