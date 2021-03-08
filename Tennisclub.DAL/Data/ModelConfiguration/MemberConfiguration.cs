using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using Tennisclub.Common.MemberDTO;
using Tennisclub.DAL.Models;

namespace Tennisclub.DAL.ModelConfiguration
{
    class MemberConfiguration : Profile, IEntityTypeConfiguration<Member>
    {
        public MemberConfiguration()
        {
            CreateMap<Member, MemberReadDto>();
            CreateMap<MemberReadDto, Member>();
            CreateMap<MemberCreateDto, Member>();
            CreateMap<Member, MemberCreateDto>();
            CreateMap<MemberUpdateDto, Member>();
            CreateMap<Member, MemberUpdateDto>();
        }
        public void Configure(EntityTypeBuilder<Member> builder)
        {
            builder.HasKey(m => m.Id);

            builder.Property(m => m.Id).ValueGeneratedOnAdd();
            builder.Property(m => m.FederationNr).HasColumnType("varchar(10)").IsRequired();
            builder.HasIndex(m => m.FederationNr).IsUnique();
            builder.Property(m => m.FirstName).HasColumnType("varchar(25)").IsRequired();
            builder.Property(m => m.LastName).HasColumnType("varchar(35)").IsRequired();
            builder.Property(m => m.Birthdate).HasColumnType("date").IsRequired();
            builder.Property(m => m.Address).HasColumnType("varchar(70)").IsRequired();
            builder.Property(m => m.Number).HasColumnType("varchar(6)").IsRequired();
            builder.Property(m => m.Addition).HasColumnType("varchar(2)");
            builder.Property(m => m.Zipcode).HasColumnType("varchar(6)").IsRequired();
            builder.Property(m => m.City).HasColumnType("varchar(30)").IsRequired();
            builder.Property(m => m.PhoneNr).HasColumnType("varchar(15)");
            builder.Property<bool>("IsDeleted");

            builder.HasOne<Gender>(m => m.Gender).WithMany().HasForeignKey(m => m.GenderId);
        }
    }
}
