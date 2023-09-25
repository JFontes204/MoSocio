using MoSocioAPI.Model;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace MoSocioAPI.DAC.ConfigurationData
{
    internal class InstitutionTypeConfiguration : EntityTypeConfiguration<InstitutionType>
    {
        public InstitutionTypeConfiguration()
        {
            ToTable("InstitutionTypes");
            HasKey(x => x.InstitutionTypeId);

            Property(x => x.InstitutionTypeId)
                .IsRequired()
                .HasColumnName("Id")
                .HasColumnType("INT")
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(x => x.Label)
                .IsRequired()
                .HasColumnName("Name")
                .HasColumnType("NVARCHAR")
                .HasMaxLength(100);

            //Relacionamento
            HasMany(x => x.Institutions)
                .WithRequired(x => x.InstitutionType)
                .HasForeignKey(x => x.InstitutionTypeId)
                .WillCascadeOnDelete(false);
        }
    }
}
