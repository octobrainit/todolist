using TaskList.Domain.Abstractions;

namespace TaskList.Domain.Entities
{
    public record TaskBoard : BaseEntity
    {
        public string Name { get; set; } = string.Empty;
        public List<Activity> Activities { get; set; } = new();
        public TaskBoard(){}
        public TaskBoard(Guid id) {}
        public TaskBoard(string name, List<Activity> activities)
        {
            SetName(name).SetActivitie(activities);
        }

        public TaskBoard SetName(string name)
        {
            if(string.IsNullOrWhiteSpace(name) || name.Length < 3)
                throw new ArgumentException("name is not valid");
            Name = name;
            return this;
        }

        public TaskBoard SetActivitie(List<Activity> activities)
        {
            if (activities is null || activities.Count == 0)
                throw new ArgumentException("activitie is not valid");
            if (activities.Any(activity => activity == null))
                throw new ArgumentException("Activities array contains null elements");
            Activities = activities;
            return this;
        }

        public static TaskBoard Create(string name, List<Activity> activities) => 
            new(name, activities);
    }
}
