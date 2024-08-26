using Microsoft.Extensions.Logging;
using TaskList.Business.Abstractions.Handler;
using TaskList.Business.Abstractions.Repositories;

namespace TaskList.Business.Query.V1.TaskList.Get
{
    public class GetTaskBoardQueryHandler :
        BaseHandler<GetTaskBoardQuery, List<GetTaskBoardResponse>>,
        IGetTaskBoardQueryHandler
    {
        private readonly ITaskListRepository _repository;

        public GetTaskBoardQueryHandler(
            ILogger<GetTaskBoardQuery> logger,
            ITaskListRepository repository
        ) : base(logger)
        {
            _repository = repository;
        }
        public override async Task ExecuteBusiness(GetTaskBoardQuery input, CancellationToken cancellation)
        {
            _logger.LogInformation("Getting taskboard");

            var response = await _repository.GetAllWithActivitiesAsNoTracking(cancellation);

            if (response is not null)
                Response.SetData(response.Select(GetTaskBoardResponse.ParseEntityToResponse).ToList());

            _logger.LogInformation("Getted taskboard");
        }
    }
}
