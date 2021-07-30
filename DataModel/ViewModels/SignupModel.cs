using System.ComponentModel.DataAnnotations;

namespace DataModel.ViewModels {
    public class SignupModel {
        [Required(ErrorMessage = "First name is required!")]
        [StringLength(40)]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last name is required!")]
        [StringLength(40)]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Username is required!")]
        [StringLength(40)]
        [Display(Name = "Username")]
        [DataType(DataType.Text)]
        public string Name { get; set; }

        [Required(ErrorMessage = "E-mail is required!")]
        [StringLength(40)]
        [Display(Name = "Email")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is required!")]
        [StringLength(20)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Password confirmation required!")]
        [StringLength(20)]
        [DataType(DataType.Password)]
        [Display(Name = "Confirm Password")]
        [Compare("Password", ErrorMessage = "Password and confirm password does not match!")]
        public string ConfirmPassword { get; set; }
    }
}
