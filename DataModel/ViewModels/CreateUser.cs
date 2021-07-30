using System.ComponentModel.DataAnnotations;

namespace DataModel.ViewModels {
    public class CreateUser {
        [Required(ErrorMessage = "E-mail is required!")]
        [StringLength(40)]
        [Display(Name = "Email Address")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is required!")]
        [StringLength(20)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public virtual string Password { get; set; }

        [Required(ErrorMessage = "User role selection is required!")]
        [StringLength(20)]
        [Display(Name = "User Role")]
        public virtual string UserRole { get; set; }
    }
}
