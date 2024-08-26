using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using TaskList.Business.Abstractions.Repositories;
using TaskList.Data.Context;
using TaskList.Data.Repositories;

namespace TaskList.Data.Abstractions.IoC
{
    public static class Configuration
    {
        public static IServiceCollection AddDatabase(this IServiceCollection services)
        {
            var connectionString = Environment.GetEnvironmentVariable("DB_CONNECTION_STRING");

            if (string.IsNullOrEmpty(connectionString))
                throw new InvalidOperationException("String connection fault");
            
            services.AddDbContext<TaskListContext>(
                options => options.UseNpgsql(connectionString)
            );

            services.AddScoped<ITaskListRepository, TaskListRepository>();
            services.AddScoped<IActivityRepository, ActivityRepository>();

            return services;
        }
    }
}
