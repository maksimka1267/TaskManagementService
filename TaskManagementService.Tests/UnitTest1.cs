using Microsoft.AspNetCore.Mvc;
using TaskManagementService.Controllers;
using TaskManagementService.Models;
using TaskManagementService.Repository;
using TaskManagementService.Repository.Interface;
using Xunit;

namespace TaskManagementService.Tests
{
    public class TasksControllerTests
    {
        private readonly TasksController _tasksController;
        private readonly ITaskRepository _taskRepository;

        public TasksControllerTests()
        {
            _taskRepository = new InMemoryTaskRepository();
            _tasksController = new TasksController(_taskRepository);
        }

        [Fact]
        public async Task CreateTask_ShouldSetDefaultStatus()
        {
            var newTask = new TaskItem { Title = "Test" };

            var result = await _tasksController.Create(newTask) as CreatedAtActionResult;
            var task = result?.Value as TaskItem;

            Assert.NotNull(task);
            Assert.Equal(TaskStatus.Backlog, task.Status);
        }

        [Fact]
        public async Task ChangeStatus_ValidTransition_ShouldWork()
        {
            var task = await _taskRepository.AddAsync(new TaskItem { Title = "A" });

            await _tasksController.ChangeStatus(task.Id, TaskStatus.InWork);
            var updated = await _taskRepository.GetByIdAsync(task.Id);

            Assert.Equal(TaskStatus.InWork, updated?.Status);
        }

        [Fact]
        public async Task ChangeStatus_InvalidTransition_ShouldFail()
        {
            var task = await _taskRepository.AddAsync(new TaskItem { Title = "A" });

            var result = await _tasksController.ChangeStatus(task.Id, TaskStatus.Done);

            var badRequest = Assert.IsType<BadRequestObjectResult>(result);
            Assert.Equal($"Cannot change status from {TaskStatus.Backlog} to {TaskStatus.Done}", badRequest.Value);
        }
    }
}
