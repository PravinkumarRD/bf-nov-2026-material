namespace BajajInterviewApp;

public delegate string HrMessageDelegate(string department);
internal class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Bajaj Interview App!");
        try
        {
            HrMessageDelegate hrMessageDelegate = new HrMessageDelegate(SendEmailToODCBangalore);
            Console.WriteLine(hrMessageDelegate(".NET Development Department"));
            hrMessageDelegate += SendEmailToODCHyderabad;
            Console.WriteLine(hrMessageDelegate("Java Development Department"));
            Student student = new Student();
            student.SelectionEvent += MySQLStorage;
            student.RejectionEvent += OracleStorage;
            
            student.StudentId = 2992;
            student.StudentName = "John Doe";
            student.TotalMarks = 78;
            if (student.TotalMarks<95)
            {
                student.SelectionEvent -= SendEmailToHrManager;
            }
            else
            {
                student.SelectionEvent += SendEmailToHrManager;
            }
            string companyRuleAfterInterview = "Congratulations!";
            Console.WriteLine(student.CalcualteResult(student.TotalMarks));
            Console.WriteLine(companyRuleAfterInterview);
            //student.InterviewCities("Pune", "Delhi", "Chennai");
            //Console.WriteLine("");
            //student.InterviewCities("Pune", "Delhi", "Chennai", "Bangalore","Calcutta");
        }
        catch (ArgumentException ae)
        {
            Console.WriteLine(ae.Message);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
        finally
        {
            Console.WriteLine("Program execution completed!");
        }
    }
    public static string SendEmailToODCBangalore(string department)
    {
        return "Email sent to ODC Bangalore HR Manager about the selected student from " + department + " department!";
    }
    public static string SendEmailToODCHyderabad(string department)
    {
        return "Email sent to ODC Hyderabad HR Manager about the selected student from " + department + " department!";
    }
    private static void MySQLStorage()
    {
        Console.WriteLine("Selected Student Record is stored in MySQL Server!");
    }
    private static void SendEmailToHrManager()
    {
        Console.WriteLine("Email sent to HR Manager about the selected student!");
    }
    private static void OracleStorage()
    {
        Console.WriteLine("Rejected Student Record is stored in Oracle Server!");
    }
}
