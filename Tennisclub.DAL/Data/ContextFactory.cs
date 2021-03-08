using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Tennisclub.DAL.Data;

namespace Tennisclub.DAL
{
    class ContextFactory : IDesignTimeDbContextFactory<Data.TennisclubContext>
    {
        public Data.TennisclubContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile(@Directory.GetCurrentDirectory() + "/../Tennisclub.API/appsettings.json").Build();
            var builder = new DbContextOptionsBuilder<Data.TennisclubContext>();
            var connectionString = configuration.GetConnectionString("TennisclubConnection");
            builder.UseSqlServer(connectionString);
            return new Data.TennisclubContext(builder.Options);
        }
    }
}
