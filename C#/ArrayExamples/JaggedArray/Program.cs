namespace JaggedArray
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Jagged Array Example!");
            int[][] jaggedArray = new int[3][];
            jaggedArray[0] = new int[] { 100, 200, 300, 400 };
            jaggedArray[1] = new int[] { 999, 888 };
            jaggedArray[2] = new int[] { 777, 666, 555 };
            for (int i = 0; i < jaggedArray.Length; i++)
            {
                Console.WriteLine($"Row {i}:");
                for (int j = 0; j < jaggedArray[i].Length; j++)
                {
                    Console.Write(jaggedArray[i][j] + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
