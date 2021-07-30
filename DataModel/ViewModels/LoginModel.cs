using System.ComponentModel.DataAnnotations;

namespace DataModel.ViewModels {
    public class LoginModel {
        [Required(ErrorMessage = "E-mail is required!")]
        [StringLength(40)]
        [Display(Name = "Email")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is required!")]
        [StringLength(20)]
        [Display(Name = "Password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "Remember me")]
        public bool RememberMe { get; set; }
    }
}
