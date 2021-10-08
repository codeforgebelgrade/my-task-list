using System;
using System.Collections.Generic;
using ToDoList.ToDoList.Database;
using TaskValidation;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace Services
{
    public class TaskService:ITaskService
    {
        masterContext _context;

        public TaskService(masterContext context)
        {
            _context = context;
        }

        public IEnumerable<Tasks> GetAll(string category , DateTime? dt = null)
        {
            IEnumerable<Tasks> allTasks = _context.Tasks;
            IEnumerable<Tasks> categories = _context.Tasks.Where(x => category.Equals(x.Category));
            IEnumerable<Tasks> dates = _context.Tasks.Where(x => x.DueDate.Equals(dt));
            IEnumerable<Tasks> result ;

            if (category != null && DateTime.Equals(dt,new DateTime()))
            {
                result = categories;
            }
            else if (category == null && !DateTime.Equals(dt, new DateTime()))
            {
                result = dates;
            }
            else if (category != null && !DateTime.Equals(dt, new DateTime()))
            {
                result = categories.Intersect(dates);
            }
            else
            {
                result = allTasks;
            }
            return result;
            //return categories;
            //return dates;
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
