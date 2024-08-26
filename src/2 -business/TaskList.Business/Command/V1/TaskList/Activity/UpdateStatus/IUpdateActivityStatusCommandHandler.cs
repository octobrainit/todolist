using TaskList.Business.Abstractions.Handler;

namespace TaskList.Business.Command.V1.TaskList.Activity.UpdateStatus
{
    public interface IUpdateActivityStatusCommandHandler
    {
        Task<BaseResponse<UpdateActivityStatusResponse>> ExecuteAsync(UpdateActivityStatusCommand input, CancellationToken cancellation);
    }
}
