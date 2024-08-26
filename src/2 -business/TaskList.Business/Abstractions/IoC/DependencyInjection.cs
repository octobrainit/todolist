using Microsoft.Extensions.DependencyInjection;
using TaskList.Business.Command.V1.TaskList.Activity.Create;
using TaskList.Business.Command.V1.TaskList.Activity.Delete;
using TaskList.Business.Command.V1.TaskList.Activity.UpdateStatus;
using TaskList.Business.Command.V1.TaskList.Create;
using TaskList.Business.Command.V1.TaskList.Delete;
using TaskList.Business.Query.V1.TaskList.Get;

namespace TaskList.Business.Abstractions.IoC
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddBusiness(this IServiceCollection services)
        {
            services.AddScoped<ICreateTaskListCommandHandler, CreateTaskListCommandHandler>();
            services.AddScoped<IGetTaskBoardQueryHandler, GetTaskBoardQueryHandler>();
            services.AddScoped<ICreateActivityCommandHandler, CreateActivityCommandHandler>();
            services.AddScoped<IDeleteActivityCommandHandler, DeleteActivityCommandHandler>();
            services.AddScoped<IDeleteTaskBoardCommandHandler, DeleteTaskBoardCommandHandler>();
            services.AddScoped<IUpdateActivityStatusCommandHandler, UpdateActivityStatusCommandHandler>();

            return services;
        }
    }
}
