using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using Tennisclub.Common.MemberRoleDTO;
using Tennisclub.Common.RoleDTO;
using Tennisclub.DAL.Models;

namespace Tennisclub.DAL.ModelConfiguration
{
    public class MemberRoleConfiguration : Profile, IEntityTypeConfiguration<MemberRole>
    {
        public MemberRoleConfiguration()
        {
            CreateMap<MemberRole, MemberRoleReadDto>().ReverseMap();
            CreateMap<MemberRoleCreateDto, MemberRole>();
            CreateMap<MemberRoleUpdateDto, MemberRole>();
        }
        public void Configure(EntityTypeBuilder<MemberRole> builder)
        {
            builder.HasKey(mr => mr.Id);

            builder.HasIndex(mr => mr.MemberId);
            builder.HasIndex(mr => mr.RoleId);      
            builder.Property(mr => mr.StartDate).HasColumnType("date").IsRequired();
            builder.HasIndex(mr => mr.StartDate);
            builder.Property(mr => mr.EndDate).HasColumnType("date");
            builder.HasIndex(mr => mr.EndDate);
            builder.HasIndex(mr => new { mr.MemberId, mr.RoleId, mr.StartDate, mr.EndDate }).IsUnique();

            builder.HasOne<Member>(mr => mr.Member).WithMany().HasForeignKey(mr => mr.MemberId);
            builder.HasOne<Role>(mr => mr.Role).WithMany().HasForeignKey(mr => mr.RoleId);
        }
    }
}
