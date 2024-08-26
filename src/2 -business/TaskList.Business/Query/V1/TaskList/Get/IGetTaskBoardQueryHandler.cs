using TaskList.Business.Abstractions.Handler;

namespace TaskList.Business.Query.V1.TaskList.Get
{
    public interface IGetTaskBoardQueryHandler
    {
        Task<BaseResponse<List<GetTaskBoardResponse>>> ExecuteAsync(GetTaskBoardQuery input, CancellationToken cancellation);
    }
}
