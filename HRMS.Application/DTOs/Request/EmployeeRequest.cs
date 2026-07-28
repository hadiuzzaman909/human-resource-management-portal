using System.ComponentModel.DataAnnotations;

namespace HRMS.Application.DTOs.Request;

public class EmployeeRequest
{
    [Required]
    [StringLength(100)]
    public string FirstName { get; set; } = string.Empty;

    [Required]
    [StringLength(100)]
    public string LastName { get; set; } = string.Empty;

    [Required]
    [EmailAddress]
    [StringLength(150)]
    public string Email { get; set; } = string.Empty;

    [Required]
    public string Department { get; set; } = string.Empty;

    [Range(0, 1000000)]
    public decimal Salary { get; set; }
}