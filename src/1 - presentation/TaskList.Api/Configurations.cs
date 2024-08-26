using Microsoft.AspNetCore.Routing.Constraints;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using TaskList.Api.Routes;
using TaskList.Data.Context;

namespace TaskList.Api
{
    public static class Configurations
    {
        public static IServiceCollection ConfigureRouteAndSwagger(this IServiceCollection services)
        {

            services.Configure<RouteOptions>(options =>
            {
                options.SetParameterPolicy<RegexInlineRouteConstraint>("regex");
            });
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc(
                    "v1",
                    new OpenApiInfo
                    {
                        Title = "API - Tasklist",
                        Description = "Minimal APIs",
                        Version = "v1"
                    }
                );
            });

            return services;
        }

        public static WebApplication ConfigureMigrations(this WebApplication web)
        {
            using (var scope = web.Services.CreateScope())
            {
                var dbContext = scope.ServiceProvider.GetRequiredService<TaskListContext>();
                dbContext.Database.Migrate();
            }

            return web;
        }

        public static WebApplication ConfigureMiddlewares(this WebApplication web)
        {
            web.UseSwagger();

            web.AddTaskBoardRoute();

            web.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Tasklist v1");
            });

            return web;
        }
    }
}
