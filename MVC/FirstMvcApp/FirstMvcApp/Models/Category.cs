using System.ComponentModel.DataAnnotations;

namespace FirstMvcApp.Models;

public class Category
{
    public int CategoryId { get; set; }
    [Required(ErrorMessage ="Category Name is a required field!")]
    [MinLength(4,ErrorMessage ="Category Name must be minimum 4 characters long!")]
    [MaxLength(50, ErrorMessage = "Category Name must not exceed 50 characters!")]
    public string CategoryName { get; set; } = string.Empty;
    [Required(ErrorMessage = "Category Description is a required field!")]
    [MaxLength(200, ErrorMessage = "Category Name must not exceed 200 characters!")]
    public string Description { get; set; } = string.Empty;
}
