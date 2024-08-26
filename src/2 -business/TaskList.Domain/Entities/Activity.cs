using TaskList.Domain.Abstractions;

namespace TaskList.Domain.Entities
{
    public record Activity : BaseEntity
    {
        public Activity(string name, Guid taskBoardId)
        {
            Name = name;
            TaskBoardId = taskBoardId;
            TaskBoard = new(TaskBoardId);
        }

        public Activity(string name)
        {
            Name = name;
        }

        public string Name { get; private set; }
        public bool IsDone { get; private set; }

        public Guid TaskBoardId { get; private set; }
        public virtual TaskBoard TaskBoard { get; private set; }

        public Activity SetName(string name)
        {
            if (string.IsNullOrWhiteSpace(name) || name?.Length < 3)
                throw new ArgumentException("name is not valid");
            Name = name;
            return this;
        }

        public Activity SetTaskBoardId(Guid guid)
        {
            if(guid.Equals(Guid.Empty))
                throw new ArgumentException("TaskBoardId is not valid");
            TaskBoardId = guid;
            return this;
        }
        

        public void SetActivityDone() => IsDone = true;
        public void SetActivityUnDone() => IsDone = false;

        public static Activity Create(Guid taskBoardId,string name) =>
            new(name, taskBoardId);
        public static Activity Create(string name) => new(name);
    }
}
