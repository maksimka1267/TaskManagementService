using TaskManagementService.Models;
using TaskManagementService.Repository.Interface;

namespace TaskManagementService.Repository
{
    public class InMemoryTaskRepository : ITaskRepository
    {
        private readonly List<TaskItem> _tasks = new();

        public Task<IEnumerable<TaskItem>> GetAllAsync()
            => Task.FromResult<IEnumerable<TaskItem>>(_tasks);

        public Task<TaskItem?> GetByIdAsync(Guid id)
            => Task.FromResult(_tasks.FirstOrDefault(t => t.Id == id));

        public Task<TaskItem> AddAsync(TaskItem task)
        {
            _tasks.Add(task);
            return Task.FromResult(task);
        }

        public Task UpdateAsync(TaskItem task)
        {
            var index = _tasks.FindIndex(t => t.Id == task.Id);
            if (index >= 0)
                _tasks[index] = task;
            return Task.CompletedTask;
        }
    }
}
