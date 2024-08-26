using System.ComponentModel.DataAnnotations;

namespace TaskList.Business.Command.V1.TaskList.Activity.UpdateStatus
{
    public class UpdateActivityStatusCommand
    {
        [Required]
        public Guid ActivityId { get; set; }
        [Required]
        public Guid TaskBoardId { get; set; }
        public bool IsCompleted { get; set; }
    }
}
