using System.ComponentModel.DataAnnotations;

namespace PO.Entites;

public abstract class Person : BaseEntity
{
    [Required(ErrorMessage ="Contact Name is a required field!")]
    [MaxLength(100, ErrorMessage = "Contact Name can not exceed 100 characters!")]
    public string ContactName { get; set; } = string.Empty;
    [Required(ErrorMessage = "Address is a required field!")]
    [MaxLength(300, ErrorMessage = "Address can not exceed 300 characters!")]
    public string Address { get; set; } = string.Empty;
    [Required(ErrorMessage = "City is a required field!")]
    [MaxLength(100, ErrorMessage = "City can not exceed 100 characters!")]
    public string City { get; set; } = string.Empty;
}
