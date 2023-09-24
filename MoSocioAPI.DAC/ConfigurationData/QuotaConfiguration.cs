using MoSocioAPI.Model;
using System.Data.Entity.ModelConfiguration;

namespace MoSocioAPI.DAC.ConfigurationData
{
    internal class QuotaConfiguration : EntityTypeConfiguration<Quota>
    {
        public QuotaConfiguration()
        {
            ToTable("Quotas");
            HasKey(x => x.PartnerId);

            Property(x => x.QuotaId)
                    .IsRequired()
                    .HasColumnName("Id")
                    .HasColumnType("INT")
                    .HasDatabaseGeneratedOption(default);

            Property(x => x.Value)
                    .IsRequired()
                    .HasColumnName("Value")
                    .HasColumnType("NVARCHAR")
                    .HasMaxLength(100);

            Property(x => x.DateCreation)
                    .HasColumnName("DateCreation")
                    .HasColumnType("DATETIME2");

            //Relacionamentos
            HasRequired(x => x.QuotaType)
                .WithMany(x => x.Quotas)
                .HasForeignKey(x => x.QuotaTypeId)
                .WillCascadeOnDelete();

            HasRequired(x => x.Institution)
                .WithMany(x => x.Quotas)
                .HasForeignKey(x => x.InstitutionId)
                .WillCascadeOnDelete(false);
        }
    }
}
