namespace ConsoleExplorer;

internal class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Console Explorer Example!!!");
        Console.WriteLine();
        foreach (var drive in DriveInfo.GetDrives())
        {
            Console.WriteLine(drive.Name);
            DirectoryInfo directoryInfo = new DirectoryInfo(drive.Name);
            try
            {
                foreach (var directory in directoryInfo.GetDirectories())
                {
                    Console.WriteLine($"\t {directory.Name}");
                    try
                    {
                        foreach (var file in directory.GetFiles())
                        {
                            try
                            {
                                Console.WriteLine($"\t\t {file.Name}");
                            }
                            catch (UnauthorizedAccessException uae)
                            {
                                Console.WriteLine(uae.Message);
                            }
                        }
                    }
                    catch (UnauthorizedAccessException uae)
                    {
                        Console.WriteLine(uae.Message);
                    }
                    catch (Exception)
                    {

                        throw;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
