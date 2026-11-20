namespace PO.Entites;

public class Order : BaseEntity
{
    public int OrderId { get; set; }
    public DateTime OrderDate { get; set; }
    public DateTime RequiredDate { get; set; }
    public int CustomerId { get; set; }
    public Customer Customer { get; set; }
    public Invoice Invoice { get; set; }
}
