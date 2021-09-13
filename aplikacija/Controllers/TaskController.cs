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
        public IEnumerable<Tasks> GetAll()
        {
            return _service.GetAll();
        }

        [HttpPost("tasks")]
        public ContentResult NewTask([FromBody] Tasks task)
        {
            if(Validation.CheckDate(task) && Validation.CheckCategory(task))
            {
                _service.newTask(task);
                return new ContentResult() { Content = "OK", StatusCode = 200 };
            }
            else
            {
                return new ContentResult() { Content = "Incorrect format", StatusCode = 400 };
            }
        }
        
    }
}
