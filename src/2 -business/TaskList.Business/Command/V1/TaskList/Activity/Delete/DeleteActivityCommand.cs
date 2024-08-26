using System.ComponentModel.DataAnnotations;

namespace TaskList.Business.Command.V1.TaskList.Activity.Delete
{
    public class DeleteActivityCommand
    {
        [Required]
        public Guid Id { get; set; }
        [Required]
        public Guid TaskBoardId { get; set; }
    }
}
