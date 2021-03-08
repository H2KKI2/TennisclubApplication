using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using Tennisclub.Common.GameResultDTO;
using Tennisclub.DAL.Models;

namespace Tennisclub.DAL.ModelConfiguration
{
    public class GameResultConfiguration : Profile, IEntityTypeConfiguration<GameResult>
    {
        public GameResultConfiguration()
        {
            CreateMap<GameResult, GameResultReadDto>();
            CreateMap<GameResultCreateDto, GameResult>();
            CreateMap<GameResultUpdateDto, GameResult>();
        }
        public void Configure(EntityTypeBuilder<GameResult> builder)
        {
            builder.HasKey(gr => gr.Id);
            builder.Property(gr => gr.SetNr).HasColumnType("tinyint");
            builder.Property(gr => gr.ScoreTeamMember).HasColumnType("tinyint");
            builder.Property(gr => gr.ScoreOpponent).HasColumnType("tinyint");
            builder.HasIndex(gr => new { gr.GameId, gr.SetNr}).IsUnique();

            builder.HasOne<Game>(gr => gr.Game).WithMany().HasForeignKey(gr => gr.GameId);
        }
    }
}
