using Microsoft.AspNetCore.Identity;

namespace DataModel.Models {
    public class ApplicationUserRole : IdentityUserRole<string> {
        public override string UserId { get; set; }
        public override string RoleId { get; set; }

        public virtual ApplicationUser ApplicationUser { get; set; }
        public virtual ApplicationRole ApplicationRole { get; set; }
    }
}
