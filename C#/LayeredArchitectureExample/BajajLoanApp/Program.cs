using BajajCalculation;

namespace BajajLoanApp;

internal class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Bajaj Gold Loan Application!");
        ForeignSales sales = new ForeignSales();
        Console.WriteLine($"Foreign Sales Net Profit is $ {sales.SalesNetProfit(actualSales: 150000, expense: 12000, cogs: 13000)}");
        
    }
}
