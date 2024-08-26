using Microsoft.AspNetCore.Mvc;
using TaskList.Business.Command.V1.TaskList.Activity.Create;
using TaskList.Business.Command.V1.TaskList.Activity.Delete;
using TaskList.Business.Command.V1.TaskList.Activity.UpdateStatus;
using TaskList.Business.Command.V1.TaskList.Create;
using TaskList.Business.Command.V1.TaskList.Delete;
using TaskList.Business.Query.V1.TaskList.Get;

namespace TaskList.Api.Routes
{
    public static class TaskBoardRoutes
    {
        public static WebApplication AddTaskBoardRoute(this WebApplication webapp)
        {
            webapp.MapPost("/taskboard", async (
               [FromServices] ICreateTaskListCommandHandler service,
               [FromBody] CreateTaskListCommand input,
               CancellationToken cancellationToken) =>
            {
                var response = await service.ExecuteAsync(input, cancellationToken);
                return Results.Created($"", response);
            });

            webapp.MapGet("/taskboard", async (
               [FromServices] IGetTaskBoardQueryHandler service,
               CancellationToken cancellationToken) =>
            {
                var response = await service.ExecuteAsync(new GetTaskBoardQuery(), cancellationToken);
                return Results.Ok(response);
            });

            webapp.MapPost("/taskboard/{taskBoardId}/activity", async (
               [FromServices] ICreateActivityCommandHandler service,
               [FromRoute] Guid taskBoardId,
               [FromBody] string name,
               CancellationToken cancellationToken) =>
            {
                var response = await service.ExecuteAsync(
                    new CreateActivityCommand { TaskBoarId = taskBoardId, TaskName = name }, cancellationToken);
                return Results.Ok(response);
            });

            webapp.MapPatch("/taskboard/{taskBoardId}/activity/{id}", async (
              [FromServices] IUpdateActivityStatusCommandHandler service,
              [FromRoute] Guid taskBoardId,
              [FromRoute] Guid id,
              [FromBody] bool isCompleted,
              CancellationToken cancellationToken) =>
            {
                var response = await service.ExecuteAsync(
                    new UpdateActivityStatusCommand { ActivityId = id, TaskBoardId = taskBoardId, IsCompleted = isCompleted }, cancellationToken);
                return Results.Ok(response);
            });

            webapp.MapDelete("/taskboard/{taskBoardId}", async (
              [FromServices] IDeleteTaskBoardCommandHandler service,
              [FromRoute] Guid taskBoardId,
              CancellationToken cancellationToken) =>
            {
                var response = await service.ExecuteAsync(
                    new DeleteTaskBoardCommand { Id = taskBoardId }, cancellationToken);
                return Results.Ok(response);
            });

            webapp.MapDelete("/taskboard/{taskBoardId}/activity/{id}", async (
               [FromServices] IDeleteActivityCommandHandler service,
               [FromRoute] Guid id,
               [FromRoute] Guid taskBoardId,
               CancellationToken cancellationToken) =>
            {
                var response = await service.ExecuteAsync(
                    new DeleteActivityCommand { TaskBoardId = taskBoardId, Id = id }, cancellationToken);
                return Results.Ok(response);
            });

            return webapp;
        }
    }
}
