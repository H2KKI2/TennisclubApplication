using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using Tennisclub.Common.MemberFineDTO;
using Tennisclub.DAL.Models;

namespace Tennisclub.DAL.ModelConfiguration
{
    public class MemberFineConfiguration : Profile, IEntityTypeConfiguration<MemberFine>
    {
        public MemberFineConfiguration()
        {
            CreateMap<MemberFine, MemberFineReadDto>().ReverseMap();
            CreateMap<MemberFineCreateDto, MemberFine>();
            CreateMap<MemberFineUpdateDto, MemberFine>();
        }
        public void Configure(EntityTypeBuilder<MemberFine> builder)
        {
            builder.HasKey(mf => mf.Id);
            builder.Property(mf => mf.FineNumber).HasColumnType("integer");
            builder.HasIndex(mf => mf.FineNumber).IsUnique();
            builder.Property(mf => mf.Amount).HasColumnType("decimal(7,2)").IsRequired();
            builder.Property(mf => mf.HandoutDate).HasColumnType("date").IsRequired();
            builder.Property(mf => mf.PaymentDate).HasColumnType("date");

            builder.HasOne<Member>(mf => mf.Member).WithMany().HasForeignKey(m => m.MemberId);
        }
    }
}
