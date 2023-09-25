using MoSocioAPI.Model;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace MoSocioAPI.DAC.ConfigurationData
{
    internal class QuotaTypeConfiguration : EntityTypeConfiguration<QuotaType>
    {
        public QuotaTypeConfiguration()
        {
            ToTable("QuotaTypes");
            HasKey(x => x.QuotaTypeId);

            Property(x => x.QuotaTypeId)
                    .IsRequired()
                    .HasColumnName("Id")
                    .HasColumnType("INT")
                    .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(x => x.Label)
                    .IsRequired()
                    .HasColumnName("Label")
                    .HasColumnType("NVARCHAR")
                    .HasMaxLength(200);

            //Relacionamento
            HasRequired(x => x.Institution)
                .WithMany(x => x.QuotaTypes)
                .HasForeignKey(x => x.InstitutionId)
                .WillCascadeOnDelete(false); 

        }
    }
}
