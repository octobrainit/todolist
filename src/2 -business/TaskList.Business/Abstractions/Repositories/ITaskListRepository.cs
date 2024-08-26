using TaskList.Domain.Entities;

namespace TaskList.Business.Abstractions.Repositories
{
    public interface ITaskListRepository : IRepositoryBase<TaskBoard>
    {
        Task<List<TaskBoard>> GetAllWithActivitiesAsNoTracking(CancellationToken cancellation);
    }
}
