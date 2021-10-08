using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Services;
using ToDoList.ToDoList.Database;
using TaskValidation;


namespace Controllers
{
    [Route("my-todo-list")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        private readonly ITaskService _service;

        public TaskController(ITaskService service)
        {
            _service = service;
        }

        [HttpGet("tasks")]
        public IEnumerable<Tasks> GetAllTasks([FromQuery] string category, [FromQuery] DateTime dt)
        {
            return _service.GetAll(category,dt);
        }

        [HttpPost("tasks")]
        public ContentResult NewTask([FromBody] Tasks task)
        {
            return _service.NewTask(task);
        }

        [HttpPost("tasks/{taskId}")]
        public ContentResult UpdateTask([FromRoute] int taskId, [FromBody] Tasks task)
        {
            return _service.UpadateTask(taskId, task);
        }
        
    }
}
