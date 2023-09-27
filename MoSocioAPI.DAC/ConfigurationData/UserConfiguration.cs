using InvoicingPlan.Model;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace MoSocioAPI.DAC.ConfigurationData
{
    internal class UserConfiguration : EntityTypeConfiguration<User>
    {
        public UserConfiguration()
        {
            ToTable("Users");
            HasKey(x => x.Id);

            Property(x => x.Id)
                .IsRequired()
                .HasColumnName("Id")
                .HasColumnType("INT")
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(x => x.FullName)
                .IsRequired()
                .HasColumnName("FullName")
                .HasColumnType("NVARCHAR")
                .HasMaxLength(80);

            Property(x => x.Email)
                .IsRequired()
                .HasColumnName("Email")
                .HasColumnType("NVARCHAR")
                .HasMaxLength(200);

            Property(x => x.PhoneNumber)
                .HasColumnName("PhoneNumber")
                .HasColumnType("NVARCHAR")
                .HasMaxLength(20);

            Property(x => x.Password)
                .IsRequired()
                .HasColumnName("Password")
                .HasColumnType("NVARCHAR")
                .HasMaxLength(200);

            //Relacionamento
            HasMany(x => x.Roles).WithMany(x => x.Users).Map(m =>
            {
                m.ToTable("UserRole");
                m.MapLeftKey("UserId");
                m.MapRightKey("RoleId");
            });

            HasRequired(x => x.Institution)
                .WithMany(x => x.Users)
                .HasForeignKey(x => x.InstitutionId)
                .WillCascadeOnDelete();
        }
    }
}
