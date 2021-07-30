using System.ComponentModel.DataAnnotations;

namespace DataModel.ViewModels {
    public class SearchUser {
        [Required(ErrorMessage = "Enter search data first!")]
        [StringLength(40)]
        [DataType(DataType.Text)]
#pragma warning disable IDE1006 // Naming Styles
        public string data { get; set; }
#pragma warning restore IDE1006 // Naming Styles
    }
}
