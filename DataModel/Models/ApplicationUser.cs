using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataModel.Models {
    public class ApplicationUser : IdentityUser {
        [PersonalData, Column(TypeName = "varchar(100)")]
        public virtual string FirstName { get; set; }

        [PersonalData, Column(TypeName = "varchar(100)")]
        public virtual string LastName { get; set; }

        [PersonalData, Column(TypeName = "varchar(50)")]
        public virtual string Name { get; set; }

        [PersonalData, Column(TypeName = "date")]
        public DateTime CreatedAt { get; set; }

        public virtual ICollection<ApplicationUserRole> ApplicationUserRole { get; set; }

        public virtual ICollection<VerificationTokens> Tokens { get; set; }
        public virtual UserAdditionalInfo AdditionalInfos { get; set; }

        public string FullName() {
            return $"{FirstName} {LastName}";
        }
    }
}
