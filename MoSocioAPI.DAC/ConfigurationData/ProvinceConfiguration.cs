using MoSocioAPI.Model;
using System.Data.Entity.ModelConfiguration;

namespace MoSocioAPI.DAC.ConfigurationData
{
    internal class ProvinceConfiguration : EntityTypeConfiguration<Province>
    {
        public ProvinceConfiguration()
        {
            ToTable("Provinces");
            HasKey(x => x.ProvinceId);

            Property(x => x.ProvinceId)
                .IsRequired()
                .HasColumnName("Id")
                .HasColumnType("INT")
                .HasDatabaseGeneratedOption(default);

            Property(x => x.Name)
                .IsRequired()
                .HasColumnName("Name")
                .HasColumnType("NVARCHAR")
                .HasMaxLength(80);

            //Relacionamento
        }
    }
}
