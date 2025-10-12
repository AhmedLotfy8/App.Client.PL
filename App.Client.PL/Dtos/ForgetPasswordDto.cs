using System.ComponentModel.DataAnnotations;

namespace App.Client.PL.Dtos {
    public class ForgetPasswordDto {

        [Required(ErrorMessage = "Email is required!")]
        [EmailAddress]
        public string Email { get; set; }
    }
}
