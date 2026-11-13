namespace ExtensionMethods;

internal sealed class Sales
{
    public double SalesNetProfit(double cogs, double expense, double actualSales)
    {
        return actualSales - (cogs + expense);
    }
}
