using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TwitterCloneShared.SharedModels;

namespace TwitterCloneAPIUserAuth.Data
{
    public class AuthDbContext : IdentityDbContext<User>
    {
        public AuthDbContext(DbContextOptions<AuthDbContext> options) : base(options)
        {
        }

        // Override the OnModelCreating to tweak the model as needed
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Example: If you wanted to rename the ASP.NET Identity table names, you could do it here.
            // This is optional and can be removed if not needed.
            modelBuilder.Entity<User>().ToTable("AuthUsers");
            modelBuilder.Entity<IdentityRole>().ToTable("AuthRoles");
            modelBuilder.Entity<IdentityUserRole<string>>().ToTable("AuthUserRoles");
            modelBuilder.Entity<IdentityUserClaim<string>>().ToTable("AuthUserClaims");
            modelBuilder.Entity<IdentityUserLogin<string>>().ToTable("AuthUserLogins");
            modelBuilder.Entity<IdentityRoleClaim<string>>().ToTable("AuthRoleClaims");
            modelBuilder.Entity<IdentityUserToken<string>>().ToTable("AuthUserTokens");

            // Add any additional configuration here
        }
    }
}

