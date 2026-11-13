namespace ShadowingExample
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Shadowing Example!!");
            Parent parent = new Parent();
            parent.Display();
            Child child = new Child();
            child.Display();
            Parent p1 = new Child();
            p1.Display();
        }
    }
}
