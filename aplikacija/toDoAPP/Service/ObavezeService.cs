using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using toDoAPP.Models;

namespace toDoAPP.Service
{
    public class ObavezeService : IObavezeService
    {
        ToDoDBContext _context;
        List<string> Kategorije = new List<string>()
                    {
                        "shopping",
                        "work",
                        "family",
                        "maintenance",
                        "birthdays",
                        "other"
                    };

        public ObavezeService(ToDoDBContext context)
        {
            _context = context;
        }

        public IEnumerable<Obaveze> GetAll()
        {
            return _context.Obavezes;
        }

        public void napraviObavezu(Obaveze novaObaveza)
        {
            _context.Add(novaObaveza);
            _context.SaveChanges();
        }

        public ContentResult proveriPodatke(Obaveze novaObaveza)
        {
            
            if (!Kategorije.Any(x => novaObaveza.Kategorija.Contains(x, StringComparison.OrdinalIgnoreCase)))
            {
                return new ContentResult() { Content = " Kategorija ne postoji! ", StatusCode = 400 };
            }
            else if (novaObaveza.DatIzvrsenja == null)
            {
                return new ContentResult() { Content = "Pogresan format datuma!", StatusCode = 400 };
            }
            else 
            {
                napraviObavezu(novaObaveza);
                return new ContentResult() { Content = "OK", StatusCode = 200 };
            }

            
        }
    }
}
