using Microsoft.Extensions.Logging;
using TaskList.Business.Abstractions.Handler;
using TaskList.Business.Abstractions.Repositories;

namespace TaskList.Business.Command.V1.TaskList.Activity.Create
{
    public class CreateActivityCommandHandler :
        BaseHandler<CreateActivityCommand, CreateActivityResponse>,
        ICreateActivityCommandHandler
    {
        private readonly ITaskListRepository _taskListRepository;

        public CreateActivityCommandHandler(
            ILogger<CreateActivityCommand> logger,
            ITaskListRepository taskListRepository
        ) : base(logger)
        {
            _taskListRepository = taskListRepository;
        }
        public override async Task ExecuteBusiness(CreateActivityCommand input, CancellationToken cancellation)
        {
            _logger.LogInformation("Starting add activity");

            var taskBoart = await _taskListRepository.FindByIdAsyncAsNoTracking(input.TaskBoarId, cancellation);

            if (taskBoart is null)
                return;

            taskBoart?.Activities.Add(Domain.Entities.Activity.Create(input.TaskBoarId, input.TaskName));

            await _taskListRepository.UpdateAsync(taskBoart);

            Response.SetData(new CreateActivityResponse { Id = taskBoart.Activities.First().Id });

            _logger.LogInformation("ended add activity");
        }
    }
}
