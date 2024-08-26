using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using TaskList.Business.Abstractions.Repositories;
using TaskList.Data.Abstractions.Repository;
using TaskList.Data.Context;
using TaskList.Domain.Entities;

namespace TaskList.Data.Repositories
{
    public class TaskListRepository : RepositoryBase<TaskBoard>, ITaskListRepository
    {
        public TaskListRepository(
            ILogger<TaskListContext> logger, 
            TaskListContext context
        ) : base(logger, context){}

        public async Task<List<TaskBoard>> GetAllWithActivitiesAsNoTracking(CancellationToken cancellation)
        {
            try
            {
                _logger.LogInformation("Getting data from the database");

                var response = await _context
                                        .Set<TaskBoard>()
                                        .Where(item => item.IsDelete.Equals(false))
                                        .Select(item => new
                                        {
                                            TaskBoard = item,
                                            Activities = item.Activities.Where(act => act.IsDelete.Equals(false)).ToList()
                                        })
                                        .AsNoTracking()
                                        .ToListAsync(cancellationToken: cancellation);

                var result = response.Select(r =>
                {
                    r.TaskBoard.Activities = r.Activities;
                    return r.TaskBoard;
                }).ToList();

                _logger.LogInformation("Data retrieved successfully from the database");

                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Some error ocurred when getting data {nameof(TaskBoard)}");
                throw;
            }
        }
    }
}
