using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Models.ViewModels.Identities
{
    /// <summary>
    ///     Register view model
    /// </summary>
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "Name is required.")]
        [DisplayName]
        [DataType(DataType.Text)]
        public string Name { get; set; }

        [Required(ErrorMessage = "Username is required")]
        [StringLength(10, MinimumLength = 6)]
        [DataType(DataType.Text)]
        public string Username { get; set; }
        
        [Required(ErrorMessage = "Password is required")]
        [StringLength(255, ErrorMessage = "Must be between 6 and 255 characters", MinimumLength = 6)]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        
        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
    }
}