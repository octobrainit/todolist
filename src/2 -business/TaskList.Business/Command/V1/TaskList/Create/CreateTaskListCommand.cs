using System.ComponentModel.DataAnnotations;
using TaskList.Domain.Entities;

namespace TaskList.Business.Command.V1.TaskList.Create
{
    public class CreateTaskListCommand
    {
        [Required]
        [MinLength(3)]
        public string Name { get; set; }

        [Required]
        [MinLength(3)]
        public string ActivityDescription { get; set; }

        public TaskBoard ParseToEntity()
        {
            var taskboard = TaskBoard.Create(Name,
                [
                    Domain.Entities.Activity.Create(ActivityDescription)
                ]);
            return taskboard;
        }
    }
}
