using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Tennisclub.DAL.ModelConfiguration;
using Tennisclub.DAL.Models;

namespace Tennisclub.DAL.Data
{
    public class TennisclubContext : DbContext
    {
        public TennisclubContext(DbContextOptions<TennisclubContext> opt) : base(opt)
        { }

        public DbSet<Member> Members { get; set; }
        public DbSet<Gender> Genders { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<League> Leagues { get; set; }
        public DbSet<Game> Games { get; set; }
        public DbSet<MemberRole> MemberRoles { get; set; }
        public DbSet<MemberFine> MemberFines { get; set; }
        public DbSet<GameResult> GameResults { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new MemberConfiguration());
            modelBuilder.ApplyConfiguration(new GenderConfiguration());
            modelBuilder.ApplyConfiguration(new MemberRoleConfiguration());
            modelBuilder.ApplyConfiguration(new RoleConfiguration());
            modelBuilder.ApplyConfiguration(new LeagueConfiguration());
            modelBuilder.ApplyConfiguration(new MemberFineConfiguration());
            modelBuilder.ApplyConfiguration(new GameConfiguration());
            modelBuilder.ApplyConfiguration(new GameResultConfiguration());
        }      
    }
}
