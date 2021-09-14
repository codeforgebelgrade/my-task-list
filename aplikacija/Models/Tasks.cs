using System;
using System.Collections.Generic;

#nullable disable

namespace ToDoList.ToDoList.Database
{
    public partial class Tasks
    {
        public int TaskId { get; set; }
        public string DueDate { get; set; }
        public string Task1 { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
    }
}
