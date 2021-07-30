using System.ComponentModel.DataAnnotations;

namespace DataModel.ViewModels {
    public class ChangeProfileDetails {
        [Required(ErrorMessage = "First name is required!")]
        [StringLength(40)]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last name is required!")]
        [StringLength(40)]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "E-mail is required!")]
        [StringLength(40)]
        [Display(Name = "Email")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
    }
}
