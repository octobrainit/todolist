using TaskList.Domain.Entities;

namespace TaskList.Business.Query.V1.TaskList.Get
{
    public class GetTaskBoardResponse
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public List<GetTaskBoardActivityResponse> Activities { get; set; } = new();

        public static GetTaskBoardResponse ParseEntityToResponse(TaskBoard entity)
        {
            return new GetTaskBoardResponse
            {
                Id = entity.Id,
                Name = entity.Name,
                Activities = entity.Activities
                            .Select(item =>
                                new GetTaskBoardActivityResponse
                                {
                                    Id = item.Id,
                                    Name = item.Name,
                                    isDone = item.IsDone,
                                })
                            .ToList()
            };
        }
    }

    public class GetTaskBoardActivityResponse
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public bool isDone { get; set; }
    }
}
