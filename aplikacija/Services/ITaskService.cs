﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoList.ToDoList.Database;

namespace Services
{
    public interface ITaskService
    {
        IEnumerable<Tasks> GetAll();
        Tasks NewTask(Tasks newTask);
        Tasks UpadateTask(Tasks updatedTask);
        Tasks FindTask(int id);
    }
}
