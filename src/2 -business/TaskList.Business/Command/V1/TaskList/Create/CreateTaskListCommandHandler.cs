using Microsoft.Extensions.Logging;
using TaskList.Business.Abstractions.Handler;
using TaskList.Business.Abstractions.Repositories;

namespace TaskList.Business.Command.V1.TaskList.Create
{
    public class CreateTaskListCommandHandler :
        BaseHandler<CreateTaskListCommand, CreateTaskListResponse>,
        ICreateTaskListCommandHandler
    {
        private readonly ITaskListRepository _taskListRepository;

        public CreateTaskListCommandHandler(
            ILogger<CreateTaskListCommand> logger,
            ITaskListRepository taskListRepository
        )
            : base(logger)
        {
            _taskListRepository = taskListRepository;
        }
        public override async Task ExecuteBusiness(CreateTaskListCommand input, CancellationToken cancellation)
        {
            _logger.LogInformation("Starting create tasklist");

            var response = await _taskListRepository.AddAsync(input.ParseToEntity());

            Response.SetData(CreateTaskListResponse.EntityToResponse(response));

            _logger.LogInformation("ended create tasklist");
        }
    }
}
