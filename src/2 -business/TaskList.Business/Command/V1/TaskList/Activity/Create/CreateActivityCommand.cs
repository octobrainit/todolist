using System.ComponentModel.DataAnnotations;

namespace TaskList.Business.Command.V1.TaskList.Activity.Create
{
    public class CreateActivityCommand
    {
        [Required]
        public Guid TaskBoarId { get; set; }
        [Required]
        [MinLength(3)]
        public string TaskName { get; set; }

        public Domain.Entities.Activity ParseToEntity()
        {
            return Domain.Entities.Activity.Create(TaskBoarId, TaskName);
        }
    }
}
