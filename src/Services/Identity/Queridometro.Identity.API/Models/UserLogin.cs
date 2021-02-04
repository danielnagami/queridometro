using System.ComponentModel.DataAnnotations;

namespace Queridometro.Identity.API.Models
{
    public class UserLogin
    {
        [Required(ErrorMessage = "The field {0} it's mandatory")]
        [EmailAddress(ErrorMessage = "The field {0} it's in an invalid format.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "The field {0} it's mandatory")]
        public string Password { get; set; }
    }
}