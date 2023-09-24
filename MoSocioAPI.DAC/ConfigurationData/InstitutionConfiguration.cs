using MoSocioAPI.Model;
using System.Data.Entity.ModelConfiguration;

namespace MoSocioAPI.DAC.ConfigurationData
{
    internal class InstitutionConfiguration : EntityTypeConfiguration<Institution>
    {
        public InstitutionConfiguration()
        {
            ToTable("Institutions");
            HasKey(x => x.InstitutionId);

            Property(x => x.InstitutionId)
                .IsRequired()
                .HasColumnName("Id")
                .HasColumnType("INT")
                .HasDatabaseGeneratedOption(default);

            Property(x => x.Name)
                .IsRequired()
                .HasColumnName("Name")
                .HasColumnType("NVARCHAR")
                .HasMaxLength(80);

            Property(x => x.Telefone1)
                .IsRequired()
                .HasColumnName("Telefone1")
                .HasColumnType("NVARCHAR")
                .HasMaxLength(20);

            Property(x => x.Telefone2)
                .HasColumnName("Telefone2")
                .HasColumnType("NVARCHAR")
                .HasMaxLength(20);

            Property(x => x.WhatsApp)
                .IsRequired()
                .HasColumnName("WhatsApp")
                .HasColumnType("NVARCHAR")
                .HasMaxLength(20);  
            
            Property(x => x.Email)
                .IsRequired()
                .HasColumnName("Email")
                .HasColumnType("NVARCHAR")
                .HasMaxLength(200);

            Property(x => x.HomeAddress)
                .IsRequired()
                .HasColumnName("HomeAddress")
                .HasColumnType("NVARCHAR")
                .HasMaxLength(100);

            //Relacionamento
        }
    }
}
