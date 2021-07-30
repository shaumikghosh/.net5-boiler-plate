using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using DataModel.Models;

namespace WebProject.Data {
    /* ApplicationRole, string, IdentityUserClaim<string>, ApplicationUserRole, IdentityUserLogin<string>, IdentityRoleClaim<string>, IdentityUserToken<string> */
    public class DatabaseContext : IdentityDbContext<ApplicationUser, ApplicationRole, string, IdentityUserClaim<string>, ApplicationUserRole, IdentityUserLogin<string>, IdentityRoleClaim<string>, IdentityUserToken<string>> {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options) { }
        public DbSet<ApplicationUser> User { get; set; }
        public DbSet<VerificationTokens> Tokens { get; set; }
        public DbSet<UserAdditionalInfo> AdditionalInfos { get; set; }

        protected override void OnModelCreating(ModelBuilder builder) {
            base.OnModelCreating(builder);

            CreateSuperAdmin(builder);
            CreateUser(builder);
            CreateAdmin(builder);
            UserRelationToTokens(builder);
            UserRelationToAdditionalInfo(builder);

            RelationWithUserRoleAndRoleConnector(builder);
        }

        private static void CreateSuperAdmin(ModelBuilder builder) {
            const string DEMO_SUPER_ADMIN_ID = "a18be9c0-aa65-4af8-bd17-00bd9450e575";
            const string DEMO_SUPER_ADMIN_ROLE_ID = "a18be9c0-aa65-4af8-bd17-00bd9450e900";

            builder.Entity<ApplicationRole>().HasData(
                new ApplicationRole { Id = DEMO_SUPER_ADMIN_ROLE_ID, Name = "SuperAdmin", NormalizedName = "SUPERADMIN" }
            );

            var hasher = new PasswordHasher<ApplicationUser>();

            builder.Entity<ApplicationUser>().HasData(

                new ApplicationUser {
                    Id = DEMO_SUPER_ADMIN_ID,
                    FirstName = "Super",
                    LastName = "User",
                    Name = "super-user",
                    UserName = "admin@dotnet.project",
                    NormalizedUserName = "admin@dotnet.project".ToUpper(),
                    Email = "admin@dotnet.project",
                    NormalizedEmail = "admin@dotnet.project".ToUpper(),
                    EmailConfirmed = true,
                    PhoneNumberConfirmed = true,
                    PasswordHash = hasher.HashPassword(null, "password"),
                }
            );

            builder.Entity<ApplicationUserRole>().HasData(
                new ApplicationUserRole {
                    RoleId = DEMO_SUPER_ADMIN_ROLE_ID,
                    UserId = DEMO_SUPER_ADMIN_ID
                }
            );

            builder.Entity<UserAdditionalInfo>().HasData(
                new UserAdditionalInfo {
                    UserId = DEMO_SUPER_ADMIN_ID,
                    Website = null,
                    BioData = null,
                }
            );
        }

        private static void CreateAdmin(ModelBuilder builder) {
            const string DEMO_ADMIN_ID = "a18be9c0-aa65-4af8-bd17-00bd9450e579";
            const string DEMO_ADMIN_ROLE_ID = "a18be9c0-aa65-4af8-bd17-00bd9450e909";

            builder.Entity<ApplicationRole>().HasData(
                new ApplicationRole { Id = DEMO_ADMIN_ROLE_ID, Name = "Admin", NormalizedName = "ADMIN" }
            );

            var hasher = new PasswordHasher<ApplicationUser>();

            builder.Entity<ApplicationUser>().HasData(
                new ApplicationUser {
                    Id = DEMO_ADMIN_ID,
                    FirstName = "Demo",
                    LastName = "Admin",
                    Name = "demo-admin",
                    UserName = "demoadmin@dotnet.project",
                    NormalizedUserName = "demoadmin@dotnet.project".ToUpper(),
                    Email = "demoadmin@dotnet.project",
                    NormalizedEmail = "demoadmin@dotnet.project".ToUpper(),
                    EmailConfirmed = true,
                    PhoneNumberConfirmed = true,
                    PasswordHash = hasher.HashPassword(null, "password"),
                }
            );

            builder.Entity<ApplicationUserRole>().HasData(
                new ApplicationUserRole {
                    RoleId = DEMO_ADMIN_ROLE_ID,
                    UserId = DEMO_ADMIN_ID
                }
            );

            builder.Entity<UserAdditionalInfo>().HasData(
                new UserAdditionalInfo {
                    UserId = DEMO_ADMIN_ID,
                    Website = null,
                    BioData = null,
                }
            );
        }

        private static void CreateUser(ModelBuilder builder) {
            const string DEMO_USER_ID = "a18be9c0-aa65-4af8-bd17-00bd9450e571";
            const string DEMO_USER_ROLE_ID = "a18be9c0-aa65-4af8-bd17-00bd9450e901";

            builder.Entity<ApplicationRole>().HasData(
                new ApplicationRole { Id = DEMO_USER_ROLE_ID, Name = "User", NormalizedName = "USER" }
            );

            var hasher = new PasswordHasher<ApplicationUser>();

            builder.Entity<ApplicationUser>().HasData(

                new ApplicationUser {
                    Id = DEMO_USER_ID,
                    FirstName = "Demo",
                    LastName = "User",
                    Name = "demo-user",
                    UserName = "demouser@dotnet.project",
                    NormalizedUserName = "demouser@dotnet.project".ToUpper(),
                    Email = "demouser@dotnet.project",
                    NormalizedEmail = "demouser@dotnet.project".ToUpper(),
                    EmailConfirmed = true,
                    PhoneNumberConfirmed = true,
                    PasswordHash = hasher.HashPassword(null, "password"),
                }
            );

            builder.Entity<ApplicationUserRole>().HasData(
                new ApplicationUserRole {
                    RoleId = DEMO_USER_ROLE_ID,
                    UserId = DEMO_USER_ID
                }
            );

            builder.Entity<UserAdditionalInfo>().HasData(
                new UserAdditionalInfo {
                    UserId = DEMO_USER_ID,
                    Website = null,
                    BioData = null,
                }
            );
        }

        //Database relathionship on Applicationuser, UserRole and ApplicationUserRole
        protected void RelationWithUserRoleAndRoleConnector(ModelBuilder builder) {
            builder.Entity<ApplicationUserRole>().HasKey(key => new { key.UserId, key.RoleId });

            builder.Entity<ApplicationUserRole>()
                .HasOne<ApplicationUser>(userRole => userRole.ApplicationUser)
                .WithMany(user => user.ApplicationUserRole)
                .HasForeignKey(fk => fk.UserId);

            builder.Entity<ApplicationUserRole>()
                .HasOne<ApplicationRole>(userRole => userRole.ApplicationRole)
                .WithMany(role => role.ApplicationUserRole)
                .HasForeignKey(fk => fk.RoleId)
                .OnDelete(DeleteBehavior.Cascade);
        }


        //Database relathionship on Users and verification token table
        protected void UserRelationToTokens(ModelBuilder builder) {
            builder.Entity<VerificationTokens>()
                .HasOne<ApplicationUser>(x => x.User)
                .WithMany(x => x.Tokens)
                .OnDelete(DeleteBehavior.Cascade);
        }

        //Database relathionship on Users and userAdditionalInfo table
        protected void UserRelationToAdditionalInfo(ModelBuilder builder) {
            builder.Entity<UserAdditionalInfo>().HasKey(key => key.UserId);

            builder.Entity<UserAdditionalInfo>()
                .HasOne<ApplicationUser>(x => x.User)
                .WithOne(x => x.AdditionalInfos)
                .HasForeignKey<UserAdditionalInfo>(x => x.UserId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
