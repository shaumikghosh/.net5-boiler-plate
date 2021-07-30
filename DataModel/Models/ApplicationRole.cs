using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace DataModel.Models {
    public class ApplicationRole : IdentityRole {
        public override string Id { get; set; }
        public override string Name { get; set; }
        public override string NormalizedName { get; set; }
        public override string ConcurrencyStamp { get; set; }
        public virtual ICollection<ApplicationUserRole> ApplicationUserRole { get; set; }
    }
}
