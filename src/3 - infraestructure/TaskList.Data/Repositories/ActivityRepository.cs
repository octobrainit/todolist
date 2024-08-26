using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using TaskList.Business.Abstractions.Repositories;
using TaskList.Data.Abstractions.Repository;
using TaskList.Data.Context;
using TaskList.Domain.Entities;

namespace TaskList.Data.Repositories
{
    public class ActivityRepository : RepositoryBase<Activity>, IActivityRepository
    {
        public ActivityRepository(
            ILogger<TaskListContext> logger, 
            TaskListContext context
        ) : base(logger, context) {}

        public async Task DeleteActivityById(Guid id, Guid TaskBoardId)
        {
            try
            {
                _logger.LogInformation("deleting data into database");
                var data = await _context
                                        .Set<Activity>()
                                        .Where(item => item.Id.Equals(id) && item.TaskBoardId.Equals(TaskBoardId))
                                        .FirstOrDefaultAsync();

                data?.SetDeleted();
                await _context.SaveChangesAsync();

                _logger.LogInformation("deleted data into database");
            }
            catch (Exception ex)
            {
                _logger.LogError($"Some error ocurred when deleting data {nameof(Activity)}");
                throw;
            }
        }

        public async Task UpdateActivityById(Guid id, Guid TaskBoardId, bool status)
        {
            try
            {
                _logger.LogInformation("updating data into database");
                var data = await _context
                                        .Set<Activity>()
                                        .Where(item => item.Id.Equals(id) && item.TaskBoardId.Equals(TaskBoardId))
                                        .FirstOrDefaultAsync();

                if (status)
                    data?.SetActivityDone();
                else
                    data?.SetActivityUnDone();

                await _context.SaveChangesAsync();

                _logger.LogInformation("updated data into database");
            }
            catch (Exception ex)
            {
                _logger.LogError($"Some error ocurred when updating data {nameof(Activity)}");
                throw;
            }
        }
    }
}
