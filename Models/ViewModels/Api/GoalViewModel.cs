using System.ComponentModel.DataAnnotations;

namespace Models.ViewModels.Api;

public class GoalViewModel
{
    [Required(ErrorMessage = "Gaol #1 is required")]
    [StringLength(100, MinimumLength = 6)]
    [DataType(DataType.Text)]
    public string? Gaol1 { get; set; }
    
    [StringLength(100, MinimumLength = 6)]
    [DataType(DataType.Text)]
    public string? Gaol2 { get; set; }
    
    [StringLength(100, MinimumLength = 6)]
    [DataType(DataType.Text)]
    public string? Gaol3 { get; set; }
}