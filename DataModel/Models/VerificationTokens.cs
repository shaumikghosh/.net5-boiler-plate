using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataModel.Models {
    public class VerificationTokens {
        public int Id { get; set; }

        [Column(TypeName = "varchar(60)")]
        public string Token { get; set; }

        [Column(TypeName = "bit"), DefaultValue(true)]
        public bool Used { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime CreatedAt { get; set; }
        public ApplicationUser User { get; set; }
    }
}
