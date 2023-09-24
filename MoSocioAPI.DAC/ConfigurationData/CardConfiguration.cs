using MoSocioAPI.Model;
using System.Data.Entity.ModelConfiguration;

namespace MoSocioAPI.DAC.ConfigurationData
{
    internal class CardConfiguration : EntityTypeConfiguration<Card>
    {
        public CardConfiguration()
        {

        ToTable("Cards");
        HasKey(x => x.CardId);

        Property(x => x.CardId)
                .IsRequired()
                .HasColumnName("Id")
                .HasColumnType("INT")
                .HasDatabaseGeneratedOption(default);

        Property(x => x.CardNumber)
                .IsRequired()
                .HasColumnName("CardNumber")
                .HasColumnType("NVARCHAR")
                .HasMaxLength(30);

            Property(x => x.IsActived)
                    .IsRequired()
                    .HasColumnName("IsActived")
                    .HasColumnType("BIT");

            Property(x => x.WasRaised)
                    .HasColumnName("WasRaised")
                    .HasColumnType("BIT");

            Property(x => x.DateCreation)
                    .IsRequired()
                    .HasColumnName("DateCreation");

            Property(x => x.DateExpiration)
                    .IsRequired()
                    .HasColumnName("DateExpiration");

            //Relacionamento
            HasRequired(x => x.Institution)
                .WithMany(x => x.Cards)
                .HasForeignKey(x => x.InstitutionId)
                .WillCascadeOnDelete(false); 

            HasRequired(x=>x.Partner)
                .WithMany(x=>x.Cards)
                .HasForeignKey(x=>x.PartnerId)
                .WillCascadeOnDelete(false);

        }
    }
}
