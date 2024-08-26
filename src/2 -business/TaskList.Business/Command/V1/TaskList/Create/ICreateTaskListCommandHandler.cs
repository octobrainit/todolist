using TaskList.Business.Abstractions.Handler;

namespace TaskList.Business.Command.V1.TaskList.Create
{
    public interface ICreateTaskListCommandHandler
    {
        Task<BaseResponse<CreateTaskListResponse>> ExecuteAsync(CreateTaskListCommand input, CancellationToken cancellation);
    }
}
