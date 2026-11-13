namespace ExtensionMethods;

internal static class Extensions
{
    public static double SalesNetProfit(this Sales sales, double cogs, double expense, double actualSales, int gstPercentage)
    {
        double gstAmount = (actualSales * gstPercentage) / 100;
        return actualSales - (cogs + expense + gstAmount);
    }
}
