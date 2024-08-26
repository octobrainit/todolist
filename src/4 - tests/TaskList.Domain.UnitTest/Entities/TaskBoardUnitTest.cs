using FluentAssertions;
using TaskList.Domain.Entities;

namespace TaskList.Domain.UnitTest.Entities
{
    public class TaskBoardUnitTest
    {
        [Fact]
        public void Constructor_ShouldSetPropertiesCorrectly()
        {
            var name = "Test Board";
            var activities = new List<Activity> { new Activity("Test Activity", Guid.NewGuid()) };
            var taskBoard = new TaskBoard(name, activities);
            taskBoard.SetId(Guid.NewGuid());
            taskBoard.Name.Should().Be(name);
            taskBoard.Activities.Should().BeEquivalentTo(activities);
            taskBoard.Id.Should().NotBe(Guid.Empty);
        }

        [Fact]
        public void SetName_ShouldUpdateName_WhenValid()
        {
            var taskBoard = new TaskBoard(Guid.Empty);
            var newName = "New Board Name";
            taskBoard.SetName(newName);

            taskBoard.Name.Should().Be(newName);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("ab")]
        public void SetName_ShouldThrowException_WhenInvalid(string invalidName)
        {
            var taskBoard = new TaskBoard(Guid.Empty);
            Action act = () => taskBoard.SetName(invalidName);
            
            act.Should().Throw<ArgumentException>()
                .WithMessage("name is not valid");
        }

        [Fact]
        public void SetActivities_ShouldUpdateActivities_WhenValid()
        {
            var taskBoard = new TaskBoard(Guid.Empty);
            var activities = new List<Activity> { new Activity(  "Test Activity", Guid.NewGuid()) };
            taskBoard.SetActivitie(activities);

            taskBoard.Activities.Should().BeEquivalentTo(activities);
        }

        [Fact]
        public void SetActivities_ShouldThrowException_WhenNull()
        {
            var taskBoard = new TaskBoard(Guid.Empty);
            Action act = () => taskBoard.SetActivitie(null);

            act.Should().Throw<ArgumentException>()
                .WithMessage("activitie is not valid");
        }

        [Fact]
        public void Create_ShouldReturnTaskBoardWithCorrectProperties()
        {
            var name = "Test Board";
            var activities = new List<Activity> { new Activity("Test Activity", Guid.NewGuid()) };
            var taskBoard = TaskBoard.Create(name, activities);

            taskBoard.Name.Should().Be(name);
            taskBoard.Activities.Should().BeEquivalentTo(activities);
        }
        [Fact]
        public void SetActivities_ShouldThrowException_WhenActivitiesContainNullElements()
        {
            var taskBoard = new TaskBoard(Guid.Empty);
            var activities = new List<Activity>
            {
                new Activity("Activity 1", Guid.NewGuid()),
                null, 
                new Activity("Activity 3", Guid.NewGuid())
            };
            Action act = () => taskBoard.SetActivitie(activities);

            act.Should().Throw<ArgumentException>()
                .WithMessage("Activities array contains null elements");
        }

        [Fact]
        public void SetActivities_ShouldUpdateActivities_WhenAllElementsAreValid()
        {
            var taskBoard = new TaskBoard(Guid.Empty);
            var activities = new List<Activity>
            {
                new Activity("Activity 1", Guid.NewGuid()),
                new Activity("Activity 2", Guid.NewGuid()),
                new Activity("Activity 3", Guid.NewGuid())
            };
            taskBoard.SetActivitie(activities);

            taskBoard.Activities.Should().BeEquivalentTo(activities);
        }
    }
}
