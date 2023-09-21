using InvoicingPlan.Model;
using MoSocioAPI.Model;
using System.Data.Entity;

namespace MoSocioAPI.DAC
{
    public class MoSocioAPIDbContext : DbContext
        
        //IdentityDbContext<ApplicationUser>
    {
        public MoSocioAPIDbContext()
            : base("name=MoSocioAPI")
        {
        }

        public static MoSocioAPIDbContext Create()
        {
            return new MoSocioAPIDbContext();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Define the default database schema
            //modelBuilder.HasDefaultSchema("MoSocioAPI");
            //modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            //modelBuilder.Entity<ApplicationUser>().ToTable("AppUsers");
            //modelBuilder.Entity<IdentityRole>().ToTable("Roles");
            //modelBuilder.Entity<IdentityUserRole>().ToTable("UserRoles");
            //modelBuilder.Entity<IdentityUserClaim>().ToTable("UserClaims");
            //modelBuilder.Entity<IdentityUserLogin>().ToTable("UserLogins");
        }

        public DbSet<Socio> Socios { get; set; }
        public DbSet<Card> Cards { get; set; }
        public DbSet<Quota> Quotas { get; set; }
        public DbSet<Partner> Partners { get; set; }
        public DbSet<Province> Provinces { get; set; }
        public DbSet<QuotaType> QuotaTypes { get; set; }
        public DbSet<PartnerType> PartnerTypes { get; set; }
        public DbSet<Institution> Institutions { get; set; }
        public DbSet<InstitutionType> InstitutionTypes { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }

    }
}
