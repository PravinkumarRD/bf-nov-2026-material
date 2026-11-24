using System.ComponentModel.DataAnnotations;

namespace eCommerce.Domain;

public class Category
{
    [Key]
    public int CategoryId { get; set; }
    [Display(Name = "Category Name")]
    [Required(ErrorMessage = "Category Name is required.")]
    [MaxLength(50, ErrorMessage = "Category Name cannot exceed 50 characters.")]
    [MinLength(5, ErrorMessage = "Category Name cannot be less than 5 characters.")]
    public string CategoryName { get; set; } = string.Empty;
    [Display(Name = "Category Desscription")]
    [Required(ErrorMessage = "Category Description is required.")]
    [MaxLength(200, ErrorMessage = "Category Description cannot exceed 200 characters.")]
    public string Description { get; set; } = string.Empty;

    public ICollection<Product>? Products { get; set; }
}
