using System;
using System.Collections.Generic;
using System.Linq;
using ToDoList.ToDoList.Database;

namespace TaskValidation
{
    public class Validation
    {
        private static List<string> categories = new List<string>(){
            "shopping",
            "work",
            "family",
            "maintenance",
            "birthdays",
            "other"
        };

        public static bool CheckCategory(Tasks task)
        {
            return categories.Any(x => task.Category.Equals(x, StringComparison.OrdinalIgnoreCase));
        }

        public static bool CheckDate(Tasks task)
        {
            //string datum = task.DueDate.ToString();
            //DateTime datum2;
            
            //DateTime.TryParse(datum, out datum2);
            //Console.WriteLine(datum2);
            return true;
            //return DateTime.TryParse(task.DueDate, out DateTime dateValue);
            //return true;
        }

    }
}
