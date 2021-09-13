using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ToDoList.ToDoList.Database;

namespace Services
{
    public class TaskService:ITaskService
    {
        masterContext _context;

        public TaskService(masterContext context)
        {
            _context = context;
        }

        public IEnumerable<Tasks> GetAll()
        {
            return _context.Tasks;
        }

        public void newTask(Tasks newTask)
        {
            _context.Add(newTask);
            _context.SaveChanges();
        }
    }
}
