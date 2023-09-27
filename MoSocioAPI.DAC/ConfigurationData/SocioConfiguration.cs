using MoSocioAPI.Model;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace MoSocioAPI.DAC.ConfigurationData
{
    internal class SocioConfiguration : EntityTypeConfiguration<Socio>
    {
        public SocioConfiguration()
        {
            ToTable("Socios");
            HasKey(x => x.SocioId);

            Property(x => x.SocioId)
                    .IsRequired()
                    .HasColumnName("Id")
                    .HasColumnType("INT")
                    .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(x => x.NumeroSocio)
                    .IsRequired()
                    .HasColumnName("NumeroSocio")
                    .HasColumnType("NVARCHAR")
                    .HasMaxLength(80);

            Property(x => x.DataRegisto)
                    .HasColumnName("DataRegisto")
                    .HasColumnType("DATETIME2");
        }
    }
}
