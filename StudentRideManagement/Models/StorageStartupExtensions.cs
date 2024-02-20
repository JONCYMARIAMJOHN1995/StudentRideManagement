using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentRideManagement.Models
{
    public class StorageStartupExtensions
    {
    }

    internal static class StorageConfiguration
    {
        internal static void ConfigureStorages(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<StudentRideContext>(options =>
                               options.UseSqlServer(configuration.GetConnectionString("StudentDBConnection")));
        }

        internal static void SeedMigrations(IConfiguration configuration)
        {
            var optionsBuilder = new DbContextOptionsBuilder<StudentRideContext>();
            optionsBuilder.UseSqlServer(configuration.GetConnectionString("StudentDBConnection"));

            using var context = new StudentRideContext(optionsBuilder.Options);
            context.Database.Migrate();
        }
    }
}
