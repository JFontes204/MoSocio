using MoSocioAPI.Model;
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
                .HasDatabaseGeneratedOption(default);

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
