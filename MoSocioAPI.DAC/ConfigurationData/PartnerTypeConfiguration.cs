﻿using MoSocioAPI.Model;
using System.ComponentModel.DataAnnotations.Schema;
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
                    .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(x => x.Label)
                    .IsRequired()
                    .HasColumnName("Label")
                    .HasColumnType("NVARCHAR")
                    .HasMaxLength(100);

            //Relacionamentos
            HasRequired(x => x.Institution)
                .WithMany(x => x.PartnerTypes)
                .HasForeignKey(x => x.InstitutionId)
                .WillCascadeOnDelete(false); 

        }
    }
}
