using TaskList.Business.Abstractions.Handler;

namespace TaskList.Business.Command.V1.TaskList.Activity.Create
{
    public interface ICreateActivityCommandHandler
    {
        Task<BaseResponse<CreateActivityResponse>> ExecuteAsync(CreateActivityCommand input, CancellationToken cancellation);
    }
}
