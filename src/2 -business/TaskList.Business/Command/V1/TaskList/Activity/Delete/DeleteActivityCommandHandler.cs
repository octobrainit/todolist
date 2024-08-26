using Microsoft.Extensions.Logging;
using TaskList.Business.Abstractions.Handler;
using TaskList.Business.Abstractions.Repositories;

namespace TaskList.Business.Command.V1.TaskList.Activity.Delete
{
    public class DeleteActivityCommandHandler :
        BaseHandler<DeleteActivityCommand, DeleteActivityResponse>,
        IDeleteActivityCommandHandler
    {
        private readonly IActivityRepository _activityRepository;

        public DeleteActivityCommandHandler(
            ILogger<DeleteActivityCommand> logger,
            IActivityRepository activityRepository
        ) : base(logger)
        {
            _activityRepository = activityRepository;
        }
        public override async Task ExecuteBusiness(DeleteActivityCommand input, CancellationToken cancellation)
        {
            _logger.LogInformation("Starting delete activity");

            await _activityRepository.DeleteActivityById(input.Id, input.TaskBoardId);

            _logger.LogInformation("Activity deleted");
        }
    }
}
