using MoSocioAPI.Model;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace MoSocioAPI.DAC.ConfigurationData
{
    internal class PartnerConfiguration: EntityTypeConfiguration<Partner>
    {
        public PartnerConfiguration()
        {
            ToTable("Partners");
            HasKey(x => x.PartnerId);

            Property(x => x.PartnerId)
                    .IsRequired()
                    .HasColumnName("Id")
                    .HasColumnType("INT")
                    .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(x => x.Name)
                    .IsRequired()
                    .HasColumnName("Name")
                    .HasColumnType("NVARCHAR")
                    .HasMaxLength(80);

            Property(x => x.Birthday)
                    .IsRequired()
                    .HasColumnName("Birthday"); 

            Property(x => x.DocNumber)
                    .HasColumnName("DocNumber")
                    .HasColumnType("NVARCHAR")
                    .HasMaxLength(30);

            Property(x => x.Photo)
                    .HasColumnName("Photo")
                    .HasColumnType("NVARCHAR")
                    .HasMaxLength(200);

            Property(x => x.DateRegistration)
                    .HasColumnName("DateRegistration")
                    .HasColumnType("DATETIME2");

            Property(x => x.Telefone1)
                    .IsRequired()
                    .HasColumnName("Telefone1")
                    .HasColumnType("NVARCHAR")
                    .HasMaxLength(20);

            Property(x => x.Telefone2)
                    .IsRequired()
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
                    .HasMaxLength(200);

            //Relacionamento
            HasRequired(x => x.Institution)
                .WithMany(x => x.partners)
                .HasForeignKey(x => x.InstitutionId)
                .WillCascadeOnDelete(false);

            HasMany(x=>x.Quotas)
                .WithRequired(x=>x.Partner)
                .HasForeignKey(x=>x.PartnerId)
                .WillCascadeOnDelete(false);

            HasRequired(x => x.PartnerType)
                .WithMany(x => x.Partners)
                .HasForeignKey(x => x.PartnerTypeId)
                .WillCascadeOnDelete(false);


        }
    }
}
