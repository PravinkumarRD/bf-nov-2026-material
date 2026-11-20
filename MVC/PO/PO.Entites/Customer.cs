using System.ComponentModel.DataAnnotations;

namespace PO.Entites;

public class Customer : Person
{
    [Key]
    public int CustomerId { get; set; }
    public DateTime JoiningDate { get; set; }
    public bool IsActive { get; set; }
    public ICollection<Order>? Orders { get; set; }
}
