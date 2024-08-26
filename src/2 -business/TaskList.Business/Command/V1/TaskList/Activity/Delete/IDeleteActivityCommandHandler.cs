using TaskList.Business.Abstractions.Handler;

namespace TaskList.Business.Command.V1.TaskList.Activity.Delete
{
    public interface IDeleteActivityCommandHandler
    {
        Task<BaseResponse<DeleteActivityResponse>> ExecuteAsync(DeleteActivityCommand input, CancellationToken cancellation);
    }
}
