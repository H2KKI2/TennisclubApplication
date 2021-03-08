using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using Tennisclub.Common.GenderDTO;
using Tennisclub.DAL.Models;

namespace Tennisclub.DAL.ModelConfiguration
{
    public class GenderConfiguration : Profile, IEntityTypeConfiguration<Gender>
    {
        public GenderConfiguration()
        {
            CreateMap<Gender, GenderReadDto>();
        }
        public void Configure(EntityTypeBuilder<Gender> builder)
        {
            builder.HasKey(g => g.Id);
            builder.Property(g => g.Name).HasColumnType("varchar(10)").IsRequired();
            builder.HasIndex(g => g.Name).IsUnique();

            builder.HasData(
                new Gender { Id = 1, Name = "Man" },
                new Gender { Id = 2, Name = "Vrouw" }
                );
        }
    }
}
