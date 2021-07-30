using System.ComponentModel.DataAnnotations.Schema;

namespace DataModel.Models {
    public class UserAdditionalInfo {
        public string UserId { get; set; }

        [Column(TypeName = "varchar(100)")]
        public string Website { get; set; }

        [Column(TypeName = "varchar(max)")]
        public string BioData { get; set; }

        [Column(TypeName = "varchar(100)")]
        public string ProfileImage { get; set; }

        public virtual ApplicationUser User { get; set; }
    }
}
