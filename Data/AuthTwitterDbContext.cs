
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TwitterCloneShared.SharedModels;

namespace TwitterCloneAPIUserAuth.Data
{
    public class AuthTwitterDbContext : IdentityDbContext<User>
    {
        public AuthTwitterDbContext(DbContextOptions<AuthTwitterDbContext> options) : base(options) { }

        // Define other DbSet properties for other application entities here

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Customize the ASP.NET Identity tables and define relationships
        }
    }
}
