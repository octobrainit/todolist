using Microsoft.Extensions.Logging;
using TaskList.Business.Abstractions.Handler;
using TaskList.Business.Abstractions.Repositories;

namespace TaskList.Business.Command.V1.TaskList.Activity.UpdateStatus
{
    public class UpdateActivityStatusCommandHandler :
        BaseHandler<UpdateActivityStatusCommand, UpdateActivityStatusResponse>,
        IUpdateActivityStatusCommandHandler
    {
        private readonly IActivityRepository _repository;

        public UpdateActivityStatusCommandHandler(
            ILogger<UpdateActivityStatusCommand> logger,
            IActivityRepository repository
        ) : base(logger)
        {
            _repository = repository;
        }
        public override async Task ExecuteBusiness(UpdateActivityStatusCommand input, CancellationToken cancellation)
        {
            _logger.LogInformation("Updating activity status");

            await _repository.UpdateActivityById(input.ActivityId, input.TaskBoardId, input.IsCompleted);

            _logger.LogInformation("Updated activity status");
        }
    }
}
