using Microsoft.EntityFrameworkCore;
using TaskList.Domain.Entities;

namespace TaskList.Data.Context
{
    public class TaskListContext : DbContext
    {
        public TaskListContext(DbContextOptions<TaskListContext> options)
        : base(options) {}

        public DbSet<TaskBoard> TaskBoards { get; set; }
        public DbSet<Activity> Activities { get; set; }
    }
}
