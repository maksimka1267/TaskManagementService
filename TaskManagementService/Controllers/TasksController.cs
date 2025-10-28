using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TaskManagementService.Models;
using TaskManagementService.Repository.Interface;
using static System.Net.Mime.MediaTypeNames;
using TaskStatus = TaskManagementService.Models.TaskStatus;

namespace TaskManagementService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TasksController : ControllerBase
    {
        private readonly ITaskRepository _taskRepository;
        public TasksController(ITaskRepository taskRepository)
        {
            _taskRepository = taskRepository;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var tasks = await _taskRepository.GetAllAsync();
            return Ok(tasks);
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] TaskItem item)
        {
            var created = await _taskRepository.AddAsync(item);
            return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            if(id == Guid.Empty)
            {
                return BadRequest();
            }
            else
            {
                var task = await _taskRepository.GetByIdAsync(id);
                return task == null ? NotFound() : Ok(task);
            }
        }
        [HttpPost("{id}/status")]
        public async Task<IActionResult> ChangeStatus(Guid id, [FromBody] TaskStatus newStatus)
        {
            var task = await _taskRepository.GetByIdAsync(id);
            if (task == null)
                return NotFound();
            if (!IsValidTransition(task.Status, newStatus))
                return BadRequest($"Cannot change status from {task.Status} to {newStatus}");
            task.Status = newStatus;
            await _taskRepository.UpdateAsync(task);
            return Ok(task);
        }
        private bool IsValidTransition(TaskStatus status, TaskStatus newStatus) =>
            (status, newStatus) switch
            {
                (TaskStatus.Backlog, TaskStatus.InWork) => true,
                (TaskStatus.InWork, TaskStatus.Testing) => true,
                (TaskStatus.Testing, TaskStatus.Done) => true,
                _ => false
            };
    }
}
