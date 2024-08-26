using FluentAssertions;
using TaskList.Domain.Entities;

namespace TaskList.Domain.UnitTest.Entities
{
    public class ActivityUnitTest
    {
        [Fact]
        public void Create_ShouldSetPropertiesCorrectly()
        {
            var taskBoardId = Guid.NewGuid();
            var name = "Test Activity";
            var id = Guid.NewGuid();
            var activity = Activity.Create(taskBoardId, name);
            activity.SetId(id);

            activity.TaskBoardId.Should().Be(taskBoardId);
            activity.Name.Should().Be(name);
            activity.Id.Should().Be(id);
        }

        [Fact]
        public void SetName_ShouldUpdateName_WhenValid()
        {
            var activity = new Activity("Old Name", Guid.NewGuid());
            var newName = "New Name";
            activity.SetName(newName);

            activity.Name.Should().Be(newName);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("ab")]
        public void SetName_ShouldThrowException_WhenInvalid(string invalidName)
        {
            var activity = new Activity("Valid Name", Guid.NewGuid());
            Action act = () => activity.SetName(invalidName);

            act.Should().Throw<ArgumentException>()
                .WithMessage("name is not valid");
        }

        [Fact]
        public void SetTaskBoardId_ShouldUpdateTaskBoardId_WhenValid()
        {
            var activity = new Activity("Test Name", Guid.NewGuid());
            var newTaskBoardId = Guid.NewGuid();
            activity.SetTaskBoardId(newTaskBoardId);
            
            activity.TaskBoardId.Should().Be(newTaskBoardId);
        }

        [Fact]
        public void SetTaskBoardId_ShouldThrowException_WhenEmptyGuid()
        {
            var activity = new Activity("Test Name", Guid.NewGuid());
            Action act = () => activity.SetTaskBoardId(Guid.Empty);
            
            act.Should().Throw<ArgumentException>()
                .WithMessage("TaskBoardId is not valid");
        }

        [Fact]
        public void SetId_ShouldNotUpdateId_WhenIdHasValue()
        {
            var existingId = Guid.NewGuid();
            var activity = new Activity("Test Name", Guid.NewGuid());
            activity.SetId(existingId);

            activity.Id.Should().Be(existingId);
        }

        [Fact]
        public void SetId_ShouldThrowException_WhenIdIsEmpty()
        {
            var activity = new Activity("Test Name", Guid.NewGuid());
            Action act = () => activity.SetId(Guid.Empty);

            act.Should().Throw<ArgumentException>()
                .WithMessage("Id is not valid");
        }

        [Fact]
        public void SetActivityDone_ShouldMarkActivityAsDone()
        {
            var activity = new Activity("Test Name", Guid.NewGuid());
            activity.SetActivityDone();

            activity.IsDone.Should().BeTrue();
        }

        [Fact]
        public void SetActivityUndone_ShouldMarkActivityAsUndone()
        {
            var activity = new Activity("Test Name", Guid.NewGuid());
            activity.SetActivityUnDone();

            activity.IsDone.Should().BeFalse();
        }
    }
}
