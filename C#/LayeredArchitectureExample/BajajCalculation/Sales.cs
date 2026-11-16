namespace BajajCalculation;

public class Sales
{
    public int GstPercent { get; set; }
    public double SalesNetProfit(double cogs,double expense,double actualSales)
    {
        return actualSales - (cogs + expense);
    }
    public double SalesNetProfit(double cogs, double expense, double actualSales,int gst)
    {
        double gstAmount = actualSales * gst / 100;
        return actualSales - (cogs + expense + gstAmount);
    }
}
