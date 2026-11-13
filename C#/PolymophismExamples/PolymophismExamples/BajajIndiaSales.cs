namespace PolymophismExamples;

//SalesNetProfit = COGS, Expense, Actual Sales, GST

internal class BajajIndiaSales
{
    /// <summary>
    /// Use this method for internal sales net profit calculation without GST
    /// </summary>
    /// <param name="cogs">Cost of Goods and Services</param>
    /// <param name="expense">Expense done during the sales period or other costs</param>
    /// <param name="actualSales">This is incoming money from the sales</param>
    /// <returns>Sales Net Profit without GST Amount</returns>
    public double SalesNetProfit(double cogs, double expense, double actualSales)
    {
        return actualSales - (cogs + expense);
    }
    /// <summary>
    /// Use this method for external sales net profit calculation with GST
    /// </summary>
    /// <param name="cogs">Cost of Goods and Services</param>
    /// <param name="expense">Expense done during the sales period or other costs</param>
    /// <param name="actualSales">This is incoming money from the sales</param>
    /// <param name="gstPercent">This is field wise GST percentage</param>
    /// <returns>Sales Net Profit without GST Amount</returns>
    public double SalesNetProfit(double cogs, double expense, double actualSales, int gstPercentage)
    {
        double gstAmount = (actualSales * gstPercentage) / 100;
        return actualSales - (cogs + expense + gstAmount);
    }
    public virtual double NriCountryWiseExtraCharges(string country = "GulfAsia")
    {
        if (country== "GulfAsia")
        {
            return 1000;
        }
        return 2000;
    }
}

internal class BajajNriSales : BajajIndiaSales
{
    /// <summary>
    /// Use this method for external sales net profit calculation with GST
    /// </summary>
    /// <param name="cogs">Cost of Goods and Services</param>
    /// <param name="expense">Expense done during the sales period or other costs</param>
    /// <param name="actualSales">This is incoming money from the sales</param>
    /// <param name="gstPercent">This is field wise GST percentage</param>
    /// <returns>Sales Net Profit without GST Amount</returns>
    public double SalesNetProfit(double cogs, double expense, double actualSales, int gstPercentage, double nriCharges)
    {
        double gstAmount = (actualSales * gstPercentage) / 100;
        double nriShareToGovt = (nriCharges * 20) / 100;
        return (actualSales + nriCharges) - (cogs + expense + gstAmount + nriShareToGovt);
    }
    public override double NriCountryWiseExtraCharges(string country = "GulfAsia")
    {
        return 2500;
    }
}