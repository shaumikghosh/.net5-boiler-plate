using System.ComponentModel.DataAnnotations;

namespace DataModel.ViewModels {
    public class UpdateUser {
        [StringLength(30)]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [StringLength(30)]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "E-mail is required!")]
        [StringLength(40)]
        [Display(Name = "Email Address")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required(ErrorMessage = "User role selection is required!")]
        [StringLength(20)]
        [Display(Name = "User Role")]
        public string UserRole { get; set; }

        [Display(Name = "Enabled/Disabled")]
        public bool UserEnablity { get; set; }
    }
}
