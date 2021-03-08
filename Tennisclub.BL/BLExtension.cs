using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using Tennisclub.BL.Services;
using Tennisclub.BL.Services.ServiceInterfaces;
using Tennisclub.DAL.Data;

namespace Tennisclub.BL
{
    public static class BLExtension
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddTransient<IMemberService, MemberService>();
            services.AddTransient<IRoleService, RoleService>();
            services.AddTransient<IGenderService, GenderService>();
            services.AddTransient<IMemberRoleService, MemberRoleService>();
            services.AddTransient<IMemberFineService, MemberFineService>();
            services.AddTransient<ILeagueService, LeagueService>();
            services.AddTransient<IGameService, GameService>();
            services.AddTransient<IGameResultService, GameResultService>();
            return services;
        }
        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddDALRepositories();
            return services;
        }
        public static IServiceCollection RegisterContext(this IServiceCollection services,
            string connectionString)
        {
            services.AddTennisclubContext(connectionString);
            return services;
        }
    }
}
