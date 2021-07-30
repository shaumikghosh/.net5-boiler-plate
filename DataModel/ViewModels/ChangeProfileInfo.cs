using System.ComponentModel.DataAnnotations;

namespace DataModel.ViewModels {
    public class ChangeProfileInfo {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string ProfileImage { get; set; }

        [Required(ErrorMessage = "Username is required!")]
        public string Username { get; set; }
        public string Website { get; set; }
        public string BioData { get; set; }
    }
}
