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

        public Tasks FindTask(int id)
        {
            return _context.Tasks.Find(id);
        }

        public Tasks NewTask(Tasks newTask)
        {
            _context.Add(newTask);
            _context.SaveChanges();
            return newTask;
        }

        public Tasks UpadateTask(Tasks updatedTask)
        {
            var updateTask = _context.Tasks.Attach(updatedTask);
            updateTask.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();
            return updatedTask;
        }
    }
}
