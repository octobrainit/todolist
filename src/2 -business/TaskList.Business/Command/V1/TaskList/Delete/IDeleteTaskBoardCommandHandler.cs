using TaskList.Business.Abstractions.Handler;

namespace TaskList.Business.Command.V1.TaskList.Delete
{
    public interface IDeleteTaskBoardCommandHandler
    {
        Task<BaseResponse<DeleteTaskBoardResponse>> ExecuteAsync(DeleteTaskBoardCommand input, CancellationToken cancellation);
    }
}
