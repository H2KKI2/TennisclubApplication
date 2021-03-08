using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using Tennisclub.Common.GameDTO;
using Tennisclub.DAL.Models;


namespace Tennisclub.DAL.ModelConfiguration
{
    public class GameConfiguration : Profile, IEntityTypeConfiguration<Game>
    {
        public GameConfiguration()
        {
            CreateMap<Game, GameReadDto>();
            CreateMap<GameCreateDto, Game>();
            CreateMap<GameUpdateDto, Game>();
        }
        public void Configure(EntityTypeBuilder<Game> builder)
        {
            builder.HasKey(g => g.Id);
            builder.Property(g => g.GameNumber).HasColumnType("varchar(10)").IsRequired();
            builder.HasIndex(g => g.GameNumber).IsUnique();
            builder.Property(g => g.Date).HasColumnType("date").IsRequired();

            builder.HasOne<Member>(g => g.Member).WithMany().HasForeignKey(g => g.MemberId);
            builder.HasOne<League>(g => g.League).WithMany().HasForeignKey(g => g.LeagueId);
        }
    }
}
