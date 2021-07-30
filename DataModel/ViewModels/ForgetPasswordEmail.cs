using System.ComponentModel.DataAnnotations;

namespace DataModel.ViewModels {
    public class ForgetPasswordEmail {
        [Display(Name = "E-Mail"), Required(ErrorMessage = "Email is required to recover your password!")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
    }
}
