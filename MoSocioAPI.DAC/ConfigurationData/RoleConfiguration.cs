using InvoicingPlan.Model;
using System.Data.Entity.ModelConfiguration;

namespace MoSocioAPI.DAC.ConfigurationData
{
    internal class RoleConfiguration : EntityTypeConfiguration<Role>
    {
        public RoleConfiguration()
        {
            ToTable("Roles");
            HasKey(x => x.Id);

            Property(x => x.Id)
                .IsRequired()
                .HasColumnName("Id")
                .HasColumnType("INT")
                .HasDatabaseGeneratedOption(default);

            Property(x => x.Name)
                .IsRequired()
                .HasColumnName("FullName")
                .HasColumnType("NVARCHAR")
                .HasMaxLength(40);

            //Relacionamento
        }
    }
}
