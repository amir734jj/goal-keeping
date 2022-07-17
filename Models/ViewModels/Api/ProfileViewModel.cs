using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Models.Enums;

namespace Models.ViewModels.Api
{
    public class ProfileViewModel
    {
        [Required(ErrorMessage = "Name is required.")]
        [DisplayName]
        [DataType(DataType.Text)]
        public string Name { get; set; }

        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        
        [DataType(DataType.Text)]
        public string Description { get; set; }
        
        [DataType(DataType.Text)]
        public RoleEnum Role { get; set; }
    }
}