using System;
using System.Collections.Generic;
using ToDoList.ToDoList.Database;
using TaskValidation;
using Microsoft.AspNetCore.Mvc;

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

        public ContentResult NewTask(Tasks newTask)
        {
            if (Validation.CheckCategory(newTask) && Validation.CheckDate(newTask)) 
            { 
                _context.Add(newTask);
                _context.SaveChanges();
                return new ContentResult() { Content = "OK", StatusCode = 200 };
            }
            return new ContentResult() { Content = "Incorrect format", StatusCode = 400 };
        }

        public ContentResult UpadateTask(int id ,Tasks updatedTask)
        {
            Tasks oldTask = FindTask(id);
            if (Validation.CheckCategory(updatedTask) && Validation.CheckDate(updatedTask)) 
            {
                oldTask.Task1 = updatedTask.Task1;
                oldTask.DueDate = updatedTask.DueDate;
                oldTask.Description = updatedTask.Description;
                oldTask.Category = updatedTask.Category;
                
                var updateTask = _context.Tasks.Attach(oldTask);
                updateTask.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                _context.SaveChanges();
                return new ContentResult() { Content = "OK", StatusCode = 200 };
            }
            else
            {
                return new ContentResult() { Content = "Incorrect format", StatusCode = 400 };
            }

            
        }
    }
}
