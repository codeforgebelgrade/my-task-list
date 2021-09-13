using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using ToDoList.ToDoList.Database;

namespace TaskValidation
{
    public class Validation
    {
        private static List<string> Kategorije = new List<string>()
        {
            "shopping",
            "work",
            "family",
            "maintenance",
            "birthdays",
            "other"
        };

        public static Boolean CheckCategory(Tasks task)
        {
            if (Kategorije.Any(x => task.Category.Equals(x, StringComparison.OrdinalIgnoreCase)))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static Boolean CheckDate(Tasks task)
        {
            string[] date = task.DueDate.Split("-");

            try
            {
                DateTime dt = new DateTime(int.Parse(date[0]), int.Parse(date[1]), int.Parse(date[2]), 0, 0, 0);
                if (dt < DateTime.Now.Date)
                {
                    return false;
                }
            }
            catch
            {
                return false;
            }
            
            return true;
        }

    }
}
