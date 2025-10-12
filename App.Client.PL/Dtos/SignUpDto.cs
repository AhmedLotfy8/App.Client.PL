using System.ComponentModel.DataAnnotations;

namespace App.Client.PL.Dtos {
    public class SignUpDto {

        [Required(ErrorMessage ="username is required!")]
        public string UserName { get; set; }
        
        [Required(ErrorMessage ="firstName is required!")]
        public string FirstName { get; set; }

        [Required(ErrorMessage ="lastName is required!")]
        public string LastName { get; set; }
    
        [Required(ErrorMessage ="Email is required!")]
        [EmailAddress]
        public string Email { get; set; }
    
        [Required(ErrorMessage ="Password is required!")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Required(ErrorMessage ="Confirm Password is required!")]
        [Compare(nameof(Password), ErrorMessage ="confrim password doesn't match password")]
        public string ConfirmPassword { get; set; }
    
        public bool IsAgree { get; set; }

    }

}
