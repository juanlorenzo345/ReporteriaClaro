using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ReporteriaMovistar.Clients.BlazorServerSide.IdentityData.Models;
using ReporteriaMovistar.Clients.BlazorServerSide.IdentityData.Seed;

namespace ReporteriaMovistar.Clients.BlazorServerSide.IdentityData
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, string, ApplicationUserClaim, ApplicationUserRole, ApplicationUserLogin, ApplicationRoleClaim, ApplicationUserToken>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
	        base.OnModelCreating(builder);

	        builder.Entity<ApplicationUser>(b =>
	        {
		        b.ToTable("IdentityUser");
	        });

	        builder.Entity<ApplicationUserClaim>(b =>
	        {
		        b.ToTable("IdentityUserClaim");
	        });

	        builder.Entity<ApplicationUserLogin>(b =>
	        {
		        b.ToTable("IdentityUserLogin");
	        });

	        builder.Entity<ApplicationUserToken>(b =>
	        {
		        b.ToTable("IdentityUserToken");
	        });

	        builder.Entity<ApplicationRole>(b =>
	        {
		        b.ToTable("IdentityRole");
	        });

	        builder.Entity<ApplicationRoleClaim>(b =>
	        {
		        b.ToTable("IdentityRoleClaim");
	        });

	        builder.Entity<ApplicationUserRole>(b =>
	        {
		        b.ToTable("IdentityUserRole");
	        });

	        builder.Entity<ApplicationUserAccessLog>(b =>
	        {
		        b.ToTable("IdentityUserAccessLog");
	        });

	        builder.Entity<ApplicationUserExceptionLog>(b =>
	        {
		        b.ToTable("IdentityUserExceptionLog");
	        });

	        builder.Entity<ApplicationUserOperationLog>(b =>
	        {
		        b.ToTable("IdentityUserOperationLog");
	        });

			ApplicationDbContextSeedData.SeedInitialIdentityData(builder);
        }
	}
}
