using System.ComponentModel.DataAnnotations;

namespace Queridometro.Identity.API.Models
{
    public class UserRegister
    {
        [Required(ErrorMessage = "The field {0} it's mandatory")]
        [EmailAddress(ErrorMessage = "The field {0} it's in an invalid format.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "The field {0} it's mandatory")]
        [StringLength(20, ErrorMessage = "The field {0} must have between {2} and {1} characters.", MinimumLength = 6)]
        public string Password { get; set; }

        [Required(ErrorMessage = "The field {0} it's mandatory")]
        [Compare("Password", ErrorMessage = "The passowrd doesn't match.")]
        public string ConfirmPassword { get; set; }
    }
}
