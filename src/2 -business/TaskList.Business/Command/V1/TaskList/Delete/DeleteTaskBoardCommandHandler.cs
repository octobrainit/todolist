using Microsoft.Extensions.Logging;
using TaskList.Business.Abstractions.Handler;
using TaskList.Business.Abstractions.Repositories;

namespace TaskList.Business.Command.V1.TaskList.Delete
{
    public class DeleteTaskBoardCommandHandler :
        BaseHandler<DeleteTaskBoardCommand, DeleteTaskBoardResponse>,
        IDeleteTaskBoardCommandHandler
    {
        private readonly ITaskListRepository _repository;

        public DeleteTaskBoardCommandHandler(
            ILogger<DeleteTaskBoardCommand> logger,
            ITaskListRepository repository
        ) : base(logger)
        {
            _repository = repository;
        }
        public override async Task ExecuteBusiness(DeleteTaskBoardCommand input, CancellationToken cancellation)
        {
            _logger.LogInformation("Deleting TaskBoard");

            var taskboard = await _repository.FindByIdAsyncAsNoTracking(input.Id, cancellation);

            if (taskboard is not null)
            {
                taskboard.SetDeleted();
                await _repository.UpdateAsync(taskboard);
            }

            _logger.LogInformation("TaskBoard deleted");
        }
    }
}
