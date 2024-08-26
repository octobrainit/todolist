using TaskList.Domain.Entities;

namespace TaskList.Business.Abstractions.Repositories
{
    public interface IActivityRepository : IRepositoryBase<Activity> 
    {
        Task DeleteActivityById(Guid id, Guid TaskBoardId);
        Task UpdateActivityById(Guid id, Guid TaskBoardId, bool status);
    }
}
