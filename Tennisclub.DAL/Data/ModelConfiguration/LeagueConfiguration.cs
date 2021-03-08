using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using Tennisclub.Common.LeagueDTO;
using Tennisclub.DAL.Models;

namespace Tennisclub.DAL.ModelConfiguration
{
    public class LeagueConfiguration : Profile, IEntityTypeConfiguration<League>
    {
        public LeagueConfiguration()
        {
            CreateMap<League, LeagueReadDto>();
        }
        public void Configure(EntityTypeBuilder<League> builder)
        {
            builder.HasKey(l => l.Id);
            builder.Property(l => l.Name).HasColumnType("varchar(20)").IsRequired();
            builder.HasIndex(l => l.Name).IsUnique();
            builder.HasData(
                new League { Id = 1, Name = "Recreatief" },
                new League { Id = 2, Name = "Competitie" },
                new League { Id = 3, Name = "Toptennis" }
                );
        }
    }
}
