using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ToDoList.ToDoList.Database;

namespace Services
{
    public interface ITaskService
    {
        IEnumerable<Tasks> GetAll(string category = null, DateTime? dt = null);
        ContentResult NewTask(Tasks newTask);
        ContentResult UpadateTask(int id , Tasks updatedTask);
        Tasks FindTask(int id);
    }
}
