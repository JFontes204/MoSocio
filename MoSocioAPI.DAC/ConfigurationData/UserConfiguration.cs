using InvoicingPlan.Model;
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
                .HasDatabaseGeneratedOption(default);

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

        }
    }
}
