using MH = Asia.India.Maharashtar.Pune;
using AP = Asia.India.AndhraPradesh.Pune;

namespace NamespaceExamples
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            MH.Baramati baramati = new MH.Baramati();
            AP.Baramati baramati1 = new AP.Baramati();
        }
    }
}
namespace Asia
{
    namespace India
    {
        namespace Maharashtar
        {
            namespace Pune
            {
                public class Baramati
                {

                }
            }
        }
        namespace AndhraPradesh
        {
            namespace Pune
            {
                public class Baramati
                {

                }
            }
        }
    }
    namespace UAE
    {

    }
}