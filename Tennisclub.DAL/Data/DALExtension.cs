using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using Tennisclub.DAL.Repositories;
using Tennisclub.DAL.Repositories.RepositorieInterfaces;

namespace Tennisclub.DAL.Data
{
    public static class DALExtension
    {
        public static IServiceCollection AddDALRepositories(this IServiceCollection services)
        {
            services.AddTransient<IMemberRepository, MemberRepository>();
            services.AddTransient<IRoleRepository, RoleRepository>();
            services.AddTransient<IGenderRepository, GenderRepository>();
            services.AddTransient<IMemberRoleRepository, MemberRoleRepository>();
            services.AddTransient<IMemberFineRepository, MemberFineRepository>();
            services.AddTransient<ILeagueRepository, LeagueRepository>();
            services.AddTransient<IGameRepository, GameRepository>();
            services.AddTransient<IGameResultRepository, GameResultRepository>();
            return services;
        }
        public static IServiceCollection AddTennisclubContext(this IServiceCollection services,
            String connectionString)
        {
            services.AddDbContext<TennisclubContext>(
                options => options.UseSqlServer(connectionString));
            return services;
        }
        public static void AddMapper(this IServiceCollection services)
        {
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
        }
    }
}
