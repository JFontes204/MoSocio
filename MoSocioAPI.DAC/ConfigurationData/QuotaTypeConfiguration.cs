﻿using MoSocioAPI.Model;
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
                    .HasDatabaseGeneratedOption(default);

            Property(x => x.Label)
                    .IsRequired()
                    .HasColumnName("Label")
                    .HasColumnType("NVARCHAR")
                    .HasMaxLength(200);

            //Relacionamento

        }
    }
}