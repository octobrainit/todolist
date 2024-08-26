using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using TaskList.Business.Abstractions.Repositories;
using TaskList.Data.Context;
using TaskList.Domain.Abstractions;

namespace TaskList.Data.Abstractions.Repository
{
    public class RepositoryBase<TClass> :
        IRepositoryBase<TClass>
        where TClass: BaseEntity
        
    {
        protected readonly ILogger<TaskListContext> _logger;
        protected readonly TaskListContext _context;

        public RepositoryBase(
            ILogger<TaskListContext> logger,
            TaskListContext context
        )
        {
            _logger = logger;
            _context = context;
        }

        public async Task<TClass> AddAsync(TClass entity)
        {
            try
            {
                _logger.LogInformation("adding data into database");
                await _context.AddAsync(entity);
                await _context.SaveChangesAsync();
                _logger.LogInformation("added data into database");
                
                return entity;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Some error ocurred when adding data {nameof(TClass)}");
                throw;
            }
        }

        public async Task<TClass?> FindByIdAsyncAsNoTracking(Guid id, CancellationToken cancellationToken)
        {
            try
            {
                _logger.LogInformation("getting data by Id");
                var response = await _context.Set<TClass>().FirstOrDefaultAsync(item => item.Id.Equals(id));
                _logger.LogInformation("geted data by Id");

                return response;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Some error ocurred when getting data {nameof(TClass)}");
                throw;
            }
        }

        public async Task<List<TClass>?> GetAllAsyncAsNoTracking(CancellationToken cancellationToken)
        {
            try
            {
                _logger.LogInformation("getting all data");
                var response = await _context.Set<TClass>().AsNoTracking().ToListAsync();
                _logger.LogInformation("geted all data");
                
                return response;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Some error ocurred when getting all data {nameof(TClass)}");
                throw;
            }
        }

        public async Task RemoveAsync(TClass entity)
        {
            try
            {
                _logger.LogInformation("removing data");
                
                entity.SetDeleted();
                await UpdateAsync(entity);
                
                _logger.LogInformation("removed data");
            }
            catch (Exception ex)
            {
                _logger.LogError($"Some error ocurred when removing data {nameof(TClass)}");
                throw;
            }
        }

        public async Task UpdateAsync(TClass entity)
        {
            try
            {
                _logger.LogInformation("updating data");
                
                _context.Set<TClass>().Attach(entity);
                _context.Set<TClass>().Update(entity);
                await _context.SaveChangesAsync();
                
                _logger.LogInformation("updated data");
            }
            catch (Exception ex)
            {
                _logger.LogError($"Some error ocurred when updating data {nameof(TClass)}");
                throw;
            }
        }
    }
}
