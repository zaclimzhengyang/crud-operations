using System.ComponentModel.DataAnnotations;
using crud_operations.Models.Domain;

namespace crud_operations.Models;

public class AddEmployeeViewModel
{
    [Required(ErrorMessage="Name is required.")]
    [StringLength(10, ErrorMessage = "Name length must be no more than 10 characters.")]
    [Display(Name="Your Name")]
    public string Name { get; set; }
    
    [Required]
    [EmailAddress]
    public string Email { get; set; }
    
    [Required]
    public long Salary { get; set; }
    
    [Required]
    public DateTime DateOfBirth { get; set; }
    
    [Required]
    public string Department { get; set; }
}