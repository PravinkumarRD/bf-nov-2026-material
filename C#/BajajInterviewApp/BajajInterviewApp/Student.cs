namespace BajajInterviewApp;
public delegate void BajajInterviewDelegate();
internal class Student
{
    private readonly string _CompanyName; //D.I.
    public event BajajInterviewDelegate? SelectionEvent;
    public event BajajInterviewDelegate? RejectionEvent;
    public Student()
    {
        _CompanyName = "Bajaj Finserv Ltd.";
    }
    private int _StudentId;
    public int StudentId
    {
        get { return _StudentId; }
        set {
            if (value <= 0)
            {
                throw new ArgumentException("Student Id must be greater than zero.");
            }
            _StudentId = value; 
        }
    }
    //auto implemented property
    public string StudentName { get; set; } = string.Empty;
    public int TotalMarks { get; set; }
    public string CalcualteResult(int tMarks)
    {
        if (tMarks>70)
        {
            if (SelectionEvent!=null)
            {
                SelectionEvent();
            }
            return $"Student {StudentName} has been selected in {_CompanyName}!";
        }
        else
        {
            if (RejectionEvent!=null)
            {
                RejectionEvent();
            }
            return $"Student {StudentName} has been rejected from {_CompanyName}!";
        }
    }
}
