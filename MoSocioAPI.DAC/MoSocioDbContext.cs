using InvoicingPlan.Model;
using MoSocioAPI.DAC.ConfigurationData;
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

        protected override void OnModelCreating(DbModelBuilder mb)
        {
            base.OnModelCreating(mb);

            mb.Configurations.Add(new SocioConfiguration()); 
            mb.Configurations.Add(new CardConfiguration()); 
            mb.Configurations.Add(new QuotaConfiguration()); 
            mb.Configurations.Add(new PartnerConfiguration()); 
            mb.Configurations.Add(new ProvinceConfiguration()); 
            mb.Configurations.Add(new QuotaTypeConfiguration()); 
            mb.Configurations.Add(new PartnerTypeConfiguration()); 
            mb.Configurations.Add(new InstitutionConfiguration()); 
            mb.Configurations.Add(new InstitutionTypeConfiguration()); 
            mb.Configurations.Add(new UserConfiguration()); 
            mb.Configurations.Add(new RoleConfiguration()); 

            //mb.Entity<Partner>()
            //    .HasRequired(x=>x.Institution)
            //    .WithMany()
            //    .HasForeignKey(x=>x.InstitutionId)
            //    .WillCascadeOnDelete(false);

            // Define the default database schema
            //mb.HasDefaultSchema("MoSocioAPI");
            //mb.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            //mb.Entity<ApplicationUser>().ToTable("AppUsers");
            //mb.Entity<IdentityRole>().ToTable("Roles");
            //mb.Entity<IdentityUserRole>().ToTable("UserRoles");
            //mb.Entity<IdentityUserClaim>().ToTable("UserClaims");
            //mb.Entity<IdentityUserLogin>().ToTable("UserLogins");
            
           
        }

    }
}
