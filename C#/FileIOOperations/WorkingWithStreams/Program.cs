namespace WorkingWithStreams;

internal class Program
{
    static void Main(string[] args)
    {
        string path = @"D:\WebxTraining\Bajaj CDAC Nov 2026\C#\Messages.txt";
        Console.WriteLine("Stream Reader and Writer Class Examples!");

        //using (StreamWriter SW=new StreamWriter(path))
        //{
        //    SW.WriteLine("Welcome To India!");
        //    SW.WriteLine("Welcome To Bangalore!");
        //    SW.WriteLine("Welcome To Bajaj Finserv ODC!");
        //    SW.Close();
        //}
        using (StreamReader SR=new StreamReader(path))
        {
            //Console.WriteLine(SR.ReadToEnd());
            while (SR.Peek()!=-1)
            {
                Console.WriteLine(SR.ReadLine());
            }
            SR.Close();
        }
    }
}

class MyClass : IDisposable
{
    public void Dispose()
    {
        throw new NotImplementedException();
    }
}
