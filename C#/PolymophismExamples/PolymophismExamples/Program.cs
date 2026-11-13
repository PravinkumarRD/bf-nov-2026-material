namespace PolymophismExamples;

internal class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Overloading Examples!");
        BajajIndiaSales indiSales = new();
        Console.WriteLine($"Bajaj Sales Net Profit without GST is INR {indiSales.SalesNetProfit(12000, 13000, 150000)}/-");
        Console.WriteLine($"Bajaj Sales Net Profit with 18% GST is INR {indiSales.SalesNetProfit(12000, 13000, 150000, 18)}/-");
        BajajNriSales nriSales = new();
        Console.WriteLine($"Bajaj NRI Sales Net Profit is INR {nriSales.SalesNetProfit(12000, 13000, 150000, 18,1000)}/-");
        Console.WriteLine($"Nri Extra Charges are INR {nriSales.NriCountryWiseExtraCharges()}/-");
        BajajIndiaSales anotherSales=new BajajNriSales();
        Console.WriteLine($"Another Nri Extra Charges are INR {anotherSales.NriCountryWiseExtraCharges()}/-");
    }
}
