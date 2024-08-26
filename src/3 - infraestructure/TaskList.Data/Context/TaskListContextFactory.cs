using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace TaskList.Data.Context
{
    public class TaskListContextFactory : IDesignTimeDbContextFactory<TaskListContext>
    {
        public TaskListContext CreateDbContext(string[] args)
        {
            var connectionString =  Environment.GetEnvironmentVariable("DB_CONNECTION_STRING");

            var optionsBuilder = new DbContextOptionsBuilder<TaskListContext>();
            optionsBuilder.UseNpgsql(connectionString);

            return new TaskListContext(optionsBuilder.Options);
        }
    }
}
