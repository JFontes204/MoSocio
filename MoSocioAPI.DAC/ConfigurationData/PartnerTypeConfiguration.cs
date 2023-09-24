using MoSocioAPI.Model;
using System.Data.Entity.ModelConfiguration;

namespace MoSocioAPI.DAC.ConfigurationData
{
    internal class PartnerTypeConfiguration : EntityTypeConfiguration<PartnerType>
    {
        public PartnerTypeConfiguration()
        {
            ToTable("PartnerTypes");
            HasKey(x => x.PartnerTypeId);

            Property(x => x.PartnerTypeId)
                    .IsRequired()
                    .HasColumnName("Id")
                    .HasColumnType("INT")
                    .HasDatabaseGeneratedOption(default);

            Property(x => x.Label)
                    .IsRequired()
                    .HasColumnName("Label")
                    .HasColumnType("NVARCHAR")
                    .HasMaxLength(100);

            //Relacionamentos

        }
    }
}
