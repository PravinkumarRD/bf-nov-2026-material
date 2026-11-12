namespace InterfaceExamples
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            IPhysics phy = new Science();
            IChemistry chemistry=new Science();
            IScience science = new Science();
            
        }
    }
}
