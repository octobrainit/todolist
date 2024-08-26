using TaskList.Domain.Abstractions;

namespace TaskList.Business.Abstractions.Repositories
{
    public interface IRepositoryBase<TClass> where TClass : BaseEntity
    {
        Task<TClass?> FindByIdAsyncAsNoTracking(Guid id, CancellationToken cancellationToken);
        Task<List<TClass>?> GetAllAsyncAsNoTracking(CancellationToken cancellationToken);
        Task UpdateAsync(TClass entity);
        Task RemoveAsync(TClass entity);
        Task<TClass> AddAsync(TClass entity);
    }
}
