﻿using MoSocioAPI.Model;
using System.ComponentModel.DataAnnotations.Schema;
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
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(x => x.Name)
                .IsRequired()
                .HasColumnName("Name")
                .HasColumnType("NVARCHAR")
                .HasMaxLength(80);

            //Relacionamento
            HasMany(x => x.Institutions)
                .WithRequired(x => x.Province)
                .HasForeignKey(x => x.ProvinceId)
                .WillCascadeOnDelete(false);
            
            HasMany(x=>x.Partners)
                .WithRequired(x=>x.Province)
                .HasForeignKey(x => x.ProvinceId)
                .WillCascadeOnDelete(false);
        }
    }
}
