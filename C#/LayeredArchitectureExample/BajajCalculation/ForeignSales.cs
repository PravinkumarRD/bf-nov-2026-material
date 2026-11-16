namespace BajajCalculation;

public class ForeignSales : Sales
{
    public double SalesNetProfit(double cogs, double expense, double actualSales, int gst = 18, double nriCharges = 1500)
    {
        double gstAmount = actualSales * gst / 100;
        double govtNriCharges = nriCharges * 20 / 100;
        return actualSales - (cogs + expense + gstAmount + govtNriCharges) - nriCharges;
    }
}
