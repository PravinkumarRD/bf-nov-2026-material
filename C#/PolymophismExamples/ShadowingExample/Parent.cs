namespace ShadowingExample;

internal class Parent
{
    public void Display()
    {
        Console.WriteLine("Parent Class Display Method!");
    }
}

internal class Child  :Parent
{
    public new void Display()
    {
        Console.WriteLine("Child Class Display Method!");
    }
}