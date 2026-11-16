namespace FileClassExamples;

internal class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("File Class Operations!");
        string path = @"D:\WebxTraining\Bajaj CDAC Nov 2026\C#\Logs.txt";

        if (!File.Exists(path))
        {
            var FS = File.Create(path);
            FS.Close();
        }
        //StreamWriter SW = File.AppendText(path);
        //SW.WriteLine($"Today's Log Date and Time is {DateTime.Now}!");
        //SW.Close();
        //File.WriteAllLines(path, ["One","Two","Three"]);
        foreach (var item in File.ReadAllLines(path))
        {
            Console.WriteLine(item);
        }
        //File.Copy(path, "Hello.txt");
        File.Delete("Hello.txt");
        
    }
}
