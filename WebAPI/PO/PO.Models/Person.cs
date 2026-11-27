using System.ComponentModel.DataAnnotations;

namespace PO.Models;

public abstract class Person
{
    [Required(ErrorMessage = "Name is required field!")]
    [MaxLength(100, ErrorMessage = "Name can not exceed more than 100 characters")]
    public string FullName { get; set; } = string.Empty;
    [Required(ErrorMessage = "Address is required field!")]
    [MaxLength(200, ErrorMessage = "Address can not exceed more than 200 characters")]
    public string Address { get; set; } = string.Empty;
    [Required(ErrorMessage = "City is required field!")]
    [MaxLength(100, ErrorMessage = "City can not exceed more than 100 characters")]
    public string City { get; set; } = string.Empty;
    [Required(ErrorMessage = "State is required field!")]
    [MaxLength(100, ErrorMessage = "State can not exceed more than 100 characters")]
    public string State { get; set; } = string.Empty;
    [Required(ErrorMessage = "Country is required field!")]
    [MaxLength(100, ErrorMessage = "Country can not exceed more than 100 characters")]
    public string Country { get; set; } = string.Empty;
    public int Zipcode { get; set; }
    [Required(ErrorMessage = "Phone is required field!")]
    [MaxLength(15, ErrorMessage = "Phone can not exceed more than 15 characters")]
    public string Phone { get; set; } = string.Empty;
    [EmailAddress(ErrorMessage ="Email must be valid like john@bajaj.com")]
    public string? Email { get; set; }
}
