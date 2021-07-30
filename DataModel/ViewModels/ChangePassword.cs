using System.ComponentModel.DataAnnotations;

namespace DataModel.ViewModels {
    public class ChangePassword {
        [Required(ErrorMessage = "Old Password is required!")]
        [StringLength(20)]
        [DataType(DataType.Password)]
        [Display(Name = "Current Password")]
        public string CurrentPassword { get; set; }

        [Required(ErrorMessage = "New Password is required!")]
        [StringLength(20)]
        [DataType(DataType.Password)]
        [Display(Name = "New Password")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Password confirmation required!")]
        [StringLength(20)]
        [DataType(DataType.Password)]
        [Display(Name = "Confirm Password")]
        [Compare("Password", ErrorMessage = "Password and confirm password does not match!")]
        public string ConfirmPassword { get; set; }
    }
}
