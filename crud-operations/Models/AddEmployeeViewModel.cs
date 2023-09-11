using System.ComponentModel.DataAnnotations;

namespace crud_operations.Models;

public class AddEmployeeViewModel
{
    [Required]
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