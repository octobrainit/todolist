using TaskList.Domain.Entities;

namespace TaskList.Business.Command.V1.TaskList.Create
{
    public class CreateTaskListResponse
    {
        public Guid Id { get; set; }

        public static CreateTaskListResponse EntityToResponse(TaskBoard taskBoard)
        {
            return new CreateTaskListResponse
            {
                Id = taskBoard.Id,
            };
        }
    }
}
