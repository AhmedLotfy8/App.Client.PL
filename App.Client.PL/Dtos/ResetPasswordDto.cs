using System.ComponentModel.DataAnnotations;

namespace App.Client.PL.Dtos {
    public class ResetPasswordDto {

        [Required(ErrorMessage = "Password is required!")]
        [DataType(DataType.Password)]
        public string NewPassword { get; set; }

        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Confirm Password is required!")]
        [Compare(nameof(NewPassword), ErrorMessage = "confrim password doesn't match password")]
        public string ConfirmPassword { get; set; }



    }
}
