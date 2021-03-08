using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using Tennisclub.Common.RoleDTO;
using Tennisclub.DAL.Models;

namespace Tennisclub.DAL.ModelConfiguration
{
    public class RoleConfiguration : Profile, IEntityTypeConfiguration<Role>
    {
        public RoleConfiguration()
        {
            CreateMap<Role, RoleReadDto>();
            CreateMap<RoleCreateDto, Role>();
            CreateMap<Role, RoleCreateDto>();
            CreateMap<RoleUpdateDto, Role>();
        }
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.HasKey(r => r.Id);

            builder.Property(r => r.Id).ValueGeneratedOnAdd();
            builder.Property(r => r.Name).HasColumnType("varchar(20)").IsRequired();
            builder.HasIndex(r => r.Name).IsUnique();

            builder.HasData(
                new Role { Id = 1, Name = "Voorzitter"},
                new Role { Id = 2, Name = "Bestuurslid" },
                new Role { Id = 3, Name = "Secretaris" },
                new Role { Id = 4, Name = "Penningmeester" },
                new Role { Id = 5, Name = "Speler"}
                );
        }
    }
}
