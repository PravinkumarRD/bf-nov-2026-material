namespace LambdaExpressions
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Lambda Expression Examples!");
            //Single Line Lambda Expression - Void Function
            var message = () => Console.WriteLine("Welcome To Lambda Expression Void Function!");
            message();
            var square = (int num) => num * num;
            Console.WriteLine($"Square of 35 is {square(35)}");
            var SalesNetProfit = (double cogs,double expense, double actualSales, double gstPercent) =>
            {
                double gstAmount = actualSales * gstPercent / 100;
                return actualSales - (cogs + expense + gstAmount);
            };
            Console.WriteLine($"Net Profit is {SalesNetProfit(1000, 500, 2000, 18)}");
        }
        
    }
}
